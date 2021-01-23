    public class StackOverflow_6548562
    {
        public class WebserviceMessage
        {
            public string Data;
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            [WebGet(ResponseFormat = WebMessageFormat.Xml,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "MAC/{input}")]
            string MAC_Get(string input);
            [OperationContract]
            [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Xml,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "MAC/{input}")]
            WebserviceMessage MAC_Post(string input);
        }
        public class Service : ITest
        {
            public string MAC_Get(string input)
            {
                return input;
            }
            public WebserviceMessage MAC_Post(string input)
            {
                return new WebserviceMessage { Data = input };
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service/";
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/MAC/fromGET"));
            Console.WriteLine(c.UploadString(baseAddress + "/MAC/frompost", "POST", ""));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
