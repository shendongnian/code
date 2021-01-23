    public class StackOverflow_7058942
    {
        //[Serializable]
        public class Number
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
        }
        [ServiceContract]
        public class Service
        {
            [OperationContract(Name = "Add")]
            [WebInvoke(UriTemplate = "test/", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
            public int Add(Number n1)
            {
                int res = Convert.ToInt32(n1.Number1) + Convert.ToInt32(n1.Number2);
                return res;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(Service), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            c.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            c.Encoding = Encoding.UTF8;
            Console.WriteLine(c.UploadString(baseAddress + "/test/", "{\"Number1\":\"7\",\"Number2\":\"7\"}"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
