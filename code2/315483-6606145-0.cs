    public class MyWebHttpBehavior : WebHttpBehavior
    {
        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            bool isRequestWrapped = this.IsRequestWrapped(operationDescription.Behaviors.Find<WebInvokeAttribute>());
            IDispatchMessageFormatter originalFormatter = base.GetRequestDispatchFormatter(operationDescription, endpoint);
            if (isRequestWrapped)
            {
                return new MyFormUrlEncodedAwareFormatter(
                    operationDescription,
                    originalFormatter,
                    this.GetQueryStringConverter(operationDescription));
            }
            else
            {
                return originalFormatter;
            }
        }
        private bool IsRequestWrapped(WebInvokeAttribute wia)
        {
            WebMessageBodyStyle bodyStyle;
            if (wia.IsBodyStyleSetExplicitly)
            {
                bodyStyle = wia.BodyStyle;
            }
            else
            {
                bodyStyle = this.DefaultBodyStyle;
            }
            return bodyStyle == WebMessageBodyStyle.Wrapped || bodyStyle == WebMessageBodyStyle.WrappedRequest;
        }
        class MyFormUrlEncodedAwareFormatter : IDispatchMessageFormatter
        {
            const string FormUrlEncodedContentType = "application/x-www-form-urlencoded";
            OperationDescription operation;
            IDispatchMessageFormatter originalFormatter;
            QueryStringConverter queryStringConverter;
            public MyFormUrlEncodedAwareFormatter(OperationDescription operation, IDispatchMessageFormatter originalFormatter, QueryStringConverter queryStringConverter)
            {
                this.operation = operation;
                this.originalFormatter = originalFormatter;
                this.queryStringConverter = queryStringConverter;
            }
            public void DeserializeRequest(Message message, object[] parameters)
            {
                if (IsFormUrlEncodedMessage(message))
                {
                    XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
                    bodyReader.ReadStartElement("Binary");
                    byte[] bodyBytes = bodyReader.ReadContentAsBase64();
                    string body = Encoding.UTF8.GetString(bodyBytes);
                    NameValueCollection pairs = HttpUtility.ParseQueryString(body);
                    Dictionary<string, string> values = new Dictionary<string, string>();
                    foreach (var key in pairs.AllKeys)
                    {
                        values.Add(key, pairs[key]);
                    }
                    foreach (var part in this.operation.Messages[0].Body.Parts)
                    {
                        if (values.ContainsKey(part.Name))
                        {
                            string value = values[part.Name];
                            parameters[part.Index] = this.queryStringConverter.ConvertStringToValue(value, part.Type);
                        }
                        else
                        {
                            parameters[part.Index] = GetDefaultValue(part.Type);
                        }
                    }
                }
                else
                {
                    this.originalFormatter.DeserializeRequest(message, parameters);
                }
            }
            public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
            {
                throw new NotSupportedException("This is a request-only formatter");
            }
            private static bool IsFormUrlEncodedMessage(Message message)
            {
                object prop;
                if (message.Properties.TryGetValue(WebBodyFormatMessageProperty.Name, out prop))
                {
                    if (((WebBodyFormatMessageProperty)prop).Format == WebContentFormat.Raw)
                    {
                        if (message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out prop))
                        {
                            if (((HttpRequestMessageProperty)prop).Headers[HttpRequestHeader.ContentType].StartsWith(FormUrlEncodedContentType))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            private static object GetDefaultValue(Type type)
            {
                if (type.IsValueType)
                {
                    return Activator.CreateInstance(type);
                }
                else
                {
                    return null;
                }
            }
        }
    }
    [ServiceContract]
    public class Service
    {
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string Concat(string text1, string text2)
        {
            return text1 + text2;
        }
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
    class Program
    {
        public static void SendRequest(string uri, string method, string contentType, string body)
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
        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(Service), new WebHttpBinding(), "").Behaviors.Add(new MyWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            SendRequest(baseAddress + "/Add", "POST", "application/json", "{\"x\":22,\"y\":33}");
            SendRequest(baseAddress + "/Add", "POST", "application/x-www-form-urlencoded", "x=22&y=33");
            SendRequest(baseAddress + "/Add", "POST", "application/json", "{\"x\":22,\"z\":33}");
            SendRequest(baseAddress + "/Add", "POST", "application/x-www-form-urlencoded", "x=22&z=33");
            SendRequest(baseAddress + "/Concat", "POST", "application/json", "{\"text1\":\"hello\",\"text2\":\" world\"}");
            SendRequest(baseAddress + "/Concat", "POST", "application/x-www-form-urlencoded", "text1=hello&text2=%20world");
            SendRequest(baseAddress + "/Concat", "POST", "application/json", "{\"text1\":\"hello\",\"text9\":\" world\"}");
            SendRequest(baseAddress + "/Concat", "POST", "application/x-www-form-urlencoded", "text1=hello&text9=%20world");
        }
    }
