using System;
using System.Net;
using System.Net.Security;
namespace wc_downloadfile
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using(WebClient wc = new WebClient())
            {
                string src = "https://nseindia.com/content/indices/ind_nifty50list.csv";
                string dest = @"C:\temp\N50.csv";
                try
                {
					//Removed Chrome/61.0.3163.100
                    var ua = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Safari/537.36";
                    wc.Headers.Add(HttpRequestHeader.UserAgent, ua);
                    wc.Headers.Add(HttpRequestHeader.Accept, "*/*");
                    wc.DownloadFile(src, dest);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to download file  --- " + e.Message);
                }
            }
            Console.ReadKey(true);
        }
    }
}
