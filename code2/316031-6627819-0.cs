    public class Post_0424d917_89cd_43c8_be70_5d4c6934b48c
    {
        [ServiceContract]
        public interface ITest
        {
            [WebGet(UriTemplate = "/Echo?text={text}")]
            string EchoGet(string text);
            [WebInvoke(UriTemplate = "/Echo")]
            string EchoPost(string text);
            [WebGet(UriTemplate = "*")]
            Stream ErrorForGet();
            [WebInvoke(UriTemplate = "*")]
            Stream ErrorForPost();
        }
        public class Service : ITest
        {
            public string EchoGet(string text) { return text; }
            public string EchoPost(string text) { return text; }
            public Stream ErrorForPost() { return this.ErrorForGet(); }
            public Stream ErrorForGet()
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
                string result = @"<html>
      <head>
        <title>Resource not found</title>
      </head>
      <body>
        <h1>This resource cannot be found</h1>
      </body>
    </html>";
                return new MemoryStream(Encoding.UTF8.GetBytes(result));
            }
        }
        static void SendRequest(string uri, string method, string contentType, string body)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = method;
            if (!String.IsNullOrEmpty(contentType))
            {
                req.ContentType = contentType;
            }
            if (body != null)
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                req.GetRequestStream().Write(bodyBytes, 0, bodyBytes.Length);
                req.GetRequestStream().Close();
            }
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }
            Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            foreach (string headerName in resp.Headers.AllKeys)
            {
                Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
            }
            Console.WriteLine();
            Console.WriteLine(new StreamReader(resp.GetResponseStream()).ReadToEnd());
            Console.WriteLine();
            Console.WriteLine("  *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*  ");
            Console.WriteLine();
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            SendRequest(baseAddress + "/Echo?text=hello", "GET", null, null);
            SendRequest(baseAddress + "/Echo", "POST", "application/json", "\"world\"");
            SendRequest(baseAddress + "/NotFound", "GET", null, null);
            SendRequest(baseAddress + "/NotFound", "POST", "text/xml", "<body/>");
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
