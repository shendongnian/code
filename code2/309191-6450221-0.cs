    public class StackOverflow_6449723
    {
        [ServiceContract]
        public class Service
        {
            [WebGet(UriTemplate = "*", ResponseFormat = WebMessageFormat.Json)]
            public Stream GetHeaders()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var header in WebOperationContext.Current.IncomingRequest.Headers.AllKeys)
                {
                    sb.AppendLine(string.Format("{0}: {1}", header, Uri.UnescapeDataString(WebOperationContext.Current.IncomingRequest.Headers[header])));
                }
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain; charset=utf-8";
                return new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebRequest req = WebRequest.Create(baseAddress + "/foo");
            req.Headers.Add("s", Uri.EscapeDataString("АБВ12"));             
            req.Headers.Add("username", "user");
            req.Headers.Add("password", "pass");
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            Console.WriteLine(sr.ReadToEnd()); 
            
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
