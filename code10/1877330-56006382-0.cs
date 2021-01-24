    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var urlList = new List<string>();
                urlList.Add("https://jsonplaceholder.typicode.com/users");
                urlList.Add("https://jsonplaceholder.typicode.com/posts/1");
                urlList.Add("https://jsonplaceholder.typicode.com/posts/");
                SendRequesttoServer(urlList);
                Console.ReadKey();
            }
            public static void SendRequesttoServer(List<string> DomainURLs)
            {
                string strResponseValue = string.Empty;
                foreach (var DomainUrl in DomainURLs)
                {
                        var baseUri = DomainUrl.ToString();
                        if (!string.IsNullOrEmpty(baseUri))
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUri);
                            request.Method = "GET";   // DELETE\POST\GET...
                            try
                            {
                                using (HttpWebResponse resposne = (HttpWebResponse)request.GetResponse())
                                {
                                    if (resposne.StatusCode != HttpStatusCode.OK)
                                    { throw new ApplicationException("error code " + resposne.ToString()); }
                                    else
                                    {
                                        //process the response stream , can be JSON , XML , HTML...
                                        using (Stream responsestream = resposne.GetResponseStream())
                                        {
                                            if (responsestream != null)
                                            {
                                                using (StreamReader reader = new StreamReader(responsestream))
                                                {
                                                    // REST return result was store here
                                                    strResponseValue = reader.ReadToEnd();
                                                } // end of stream reader
                                            }
                                        } //End of using reponse stream
                                        Console.WriteLine("Url: " + resposne.ResponseUri.AbsoluteUri + " " + resposne.StatusCode);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message.ToString());
                            }
                        }
                }
            }
        }
    }
