    using System;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Attach my certificate validation delegate.
                ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
                System.Net.HttpWebRequest request = WebRequest.CreateHttp("https://www.google.com");
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            }
            private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
            {
                if (error == SslPolicyErrors.None)
                {
                    return true;
                }
                
                return false;
            }
        }
    }
