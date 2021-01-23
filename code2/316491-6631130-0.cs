    public class StackOverflow_6630425
    {
        [ServiceContract]
        public class Service
        {
            [WebGet]
            public string CollabSortFolder(int FolderId, Dictionary<int, int> Items)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("FolderId=" + FolderId);
                foreach (var key in Items.Keys)
                {
                    sb.AppendLine(string.Format("  Items[{0}] = {1}", key, Items[key]));
                }
                return sb.ToString();
            }
        }
        public class MyQueryStringConverter : QueryStringConverter
        {
            public override bool CanConvert(Type type)
            {
                return type == typeof(Dictionary<int, int>) || base.CanConvert(type);
            }
            public override object ConvertStringToValue(string parameter, Type parameterType)
            {
                if (parameterType == typeof(Dictionary<int, int>))
                {
                    parameter = parameter.Trim().Substring(1, parameter.Length - 2); // trimming the begin and end '{' / '}'
                    string[] pairs = parameter.Split(',');
                    Dictionary<int, int> result = new Dictionary<int, int>();
                    foreach (string pair in pairs)
                    {
                        string[] parts = pair.Split(':');
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        if (key.StartsWith("\"")) key = key.Substring(1);
                        if (key.EndsWith("\"")) key = key.Substring(0, key.Length - 1);
                        result.Add(int.Parse(key), int.Parse(value));
                    }
                    return result;
                }
                return base.ConvertStringToValue(parameter, parameterType);
            }
        }
        class MyWebHttpBehavior : WebHttpBehavior
        {
            protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
            {
                return new MyQueryStringConverter();
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(Service), new WebHttpBinding(), "").Behaviors.Add(new MyWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/CollabSortFolder?FolderId=12&Items={\"1\":3,\"4\":5,\"6\":7}"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
