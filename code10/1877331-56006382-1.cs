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
                // add  destination REST Server or IP Address into list
                urlList.Add("https://jsonplaceholder.typicode.com/users");
                urlList.Add("https://jsonplaceholder.typicode.com/posts/1");
                urlList.Add("https://jsonplaceholder.typicode.com/posts/");
                
                // Consume List items as paramter and prepare loop for processing
                SendRequesttoServer(urlList);
                // pause the console screen so it wont exit current console
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
                            // request.Proxy = WebRequest.DefaultWebProxy;                          // set proxy , this method will use default windows client proxy value
                            // WebProxy proxyObject = new WebProxy("http://pproxyserverURL:80");    // this is another method whee allow you manual set proxy server value
                            // request.Proxy = proxyObject;                                         // this is another method whee allow you manual set proxy server value
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
