    using System;
    using System.IO;
    using System.Web;
    using System.Net;
    
    public class Test
    {
        static void Main()
        {
            WebRequest request = WebRequest.Create(
                "http://www.scripts/report.asp?companyname=Google");
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    Stream recvStream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(recvStream , Encoding.UTF8);
                    XmlReader reader = XmlReader.Create(sr);
                    // Do the stuff mentioned in the MSDN article here
                    // ...
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse) response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                }
            }
        }
    }
