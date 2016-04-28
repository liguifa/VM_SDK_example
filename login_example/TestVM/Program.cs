using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vim25Api;
using Vim25Api.STSService;

namespace TestVM
{
    class Program
    {
        static VimService service = new VimService();

        static void Main(string[] args)
        {
            var _svcRef = new ManagedObjectReference();
            _svcRef.type = "ServiceInstance";
            _svcRef.Value = "ServiceInstance";

            service.Url = "https://10.2.61.62/sdk";
            service.Timeout = 1800000;
            service.CookieContainer = new System.Net.CookieContainer();
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            //ServicePoint sp = ServicePointManager.FindServicePoint(new Uri("https://10.2.61.62/client/client.xml"));
            var context = service.RetrieveServiceContent(_svcRef);
            service.Login(context.sessionManager, @"vsphere.local\administrator", "1qaz2wsx#EDC", null);


            Console.Read();
        }

    }
}
