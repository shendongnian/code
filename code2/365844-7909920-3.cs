    using System;
    using System.Collections;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Http;
    
    using CookComputing.XmlRpc;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    
    class _
    {
        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
        {
            public TrustAllCertificatePolicy() { }
            public bool CheckValidationResult(ServicePoint sp,
               X509Certificate cert,
               WebRequest req,
               int problem)
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
            IStateName proxy = XmlRpcProxyGen.Create<IStateName>();
            XmlRpcClientProtocol cp = (XmlRpcClientProtocol)proxy;
            cp.Url = "https://127.0.0.1:5678/";
            cp.ClientCertificates.Add(new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\path\to\your\certificate\file\my.cer"));
            cp.KeepAlive = false;
            //cp.Expect100Continue = false;
            //cp.NonStandard = XmlRpcNonStandard.All;
    
            string stateName = ((IStateName)cp).GetStateName(13);
        }
    }
