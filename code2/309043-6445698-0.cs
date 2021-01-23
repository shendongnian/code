    public class StackOverflow_6445171
    {
        [ServiceContract]
        public class Service
        {
            [WebGet(ResponseFormat = WebMessageFormat.Json)]
            public string GetLabelPacketTags(string query, int[] statusTypes)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Query=" + query);
                sb.Append(", statusTypes=");
                if (statusTypes == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append("[");
                    for (int i = 0; i < statusTypes.Length; i++)
                    {
                        if (i > 0) sb.Append(",");
                        sb.Append(statusTypes[i]);
                    }
                    sb.Append("]");
                }
                return sb.ToString();
            }
        }
        class MyWebHttpBehavior : WebHttpBehavior
        {
            protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
            {
                return new MyArrayAwareFormatter(operationDescription, this.GetQueryStringConverter(operationDescription));
            }
            class MyArrayAwareFormatter : IDispatchMessageFormatter
            {
                OperationDescription operation;
                QueryStringConverter queryStringConverter;
                public MyArrayAwareFormatter(OperationDescription operation, QueryStringConverter queryStringConverter)
                {
                    this.operation = operation;
                    this.queryStringConverter = queryStringConverter;
                }
                public void DeserializeRequest(Message message, object[] parameters)
                {
                    if (message.Properties.ContainsKey("UriMatched") && (bool)message.Properties["UriMatched"])
                    {
                        UriTemplateMatch match = message.Properties["UriTemplateMatchResults"] as UriTemplateMatch;
                        NameValueCollection queryValues = match.QueryParameters;
                        foreach (MessagePartDescription parameterDescr in this.operation.Messages[0].Body.Parts)
                        {
                            string parameterName = parameterDescr.Name;
                            int index = parameterDescr.Index;
                            if (parameterDescr.Type.IsArray)
                            {
                                Type elementType = parameterDescr.Type.GetElementType();
                                string[] values = queryValues.GetValues(parameterName + "[]");
                                Array array = Array.CreateInstance(elementType, values.Length);
                                for (int i = 0; i < values.Length; i++)
                                {
                                    array.SetValue(this.queryStringConverter.ConvertStringToValue(values[i], elementType), i);
                                }
                                parameters[index] = array;
                            }
                            else
                            {
                                parameters[index] = this.queryStringConverter.ConvertStringToValue(queryValues.GetValues(parameterName)[0], parameterDescr.Type);
                            }
                        }
                    }
                }
                public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
                {
                    throw new NotSupportedException("This is a request-only formatter");
                }
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
            Console.WriteLine(c.DownloadString(baseAddress + "/GetLabelPacketTags?query=some+text&statusTypes[]=1&statusTypes[]=2"));
            Console.WriteLine(c.DownloadString(baseAddress + "/GetLabelPacketTags?query=some+text&statusTypes%5B%5D=1&statusTypes%5B%5D=2"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
