    public class StackOverflow_6550019
    {
        [ServiceContract]
        public interface IfldtWholesaleService
        {
            [OperationContract]
            [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Xml,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "MAC")]
            string MAC(string input);
        }
        public class Service : IfldtWholesaleService
        {
            public string MAC(string input)
            {
                return input;
            }
        }
        private static void postToWebsite(string url)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "text/xml";
            string input = @"<MAC xmlns=""http://tempuri.org/""><input>hello</input></MAC>";
            StreamWriter writer = new StreamWriter(req.GetRequestStream());
            writer.Write(input);
            writer.Close();
            var rsp = req.GetResponse().GetResponseStream();
            Console.WriteLine(new StreamReader(rsp).ReadToEnd());
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service/";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            // To find out the expected request, using a WCF client. Look at what it sends in Fiddler
            var factory = new WebChannelFactory<IfldtWholesaleService>(new Uri(baseAddress));
            var proxy = factory.CreateChannel();
            proxy.MAC("Hello world");
            postToWebsite(baseAddress + "/MAC");
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
