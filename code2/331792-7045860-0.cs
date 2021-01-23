    public class StackOverflow_7044842
    {
        const string xml = @"<ajax-response>
    <response>
    <item>
    <number></number>
    <xxx>Não ok</xxx>
    <error>null</error>
    </item>
    </response>
    </ajax-response>";
        [ServiceContract]
        public class SimpleService
        {
            [WebGet]
            public Stream GetXml()
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
                Encoding encoding = Encoding.GetEncoding(1252);
                return new MemoryStream(encoding.GetBytes(xml));
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            WebServiceHost host = new WebServiceHost(typeof(SimpleService), new Uri(baseAddress));
            host.Open();
            Console.WriteLine("Host opened");
            WebClient client = new WebClient();
            client.Encoding = Encoding.GetEncoding(1252);
            string response = client.DownloadString(baseAddress + "/GetXml");
            Console.WriteLine(response);
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
