    public class StackOverflow_8669406
    {
        public class GetOrdersMessageFormatter : IClientMessageFormatter
        {
            readonly IClientMessageFormatter original;
            public GetOrdersMessageFormatter(IClientMessageFormatter actual)
            {
                original = actual;
            }
            public void AddArrayNamespace(XmlNode node)
            {
                if (node != null)
                {
                    var attribute = node.OwnerDocument.CreateAttribute("test");
                    attribute.Value = "test";
                    node.Attributes.Append(attribute);
                }
            }
            public object DeserializeReply(Message message, object[] parameters)
            {
                return original.DeserializeReply(message, parameters);
            }
            public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
            {
                Message newMessage = null;
                var message = original.SerializeRequest(messageVersion, parameters);
                if (message.Headers.Action == "urn:Mage_Api_Model_Server_HandlerAction")
                {
                    var doc = new XmlDocument();
                    using (var reader = message.GetReaderAtBodyContents())
                    {
                        doc.Load(reader);
                    }
                    if (doc.DocumentElement != null)
                    {
                        switch (doc.DocumentElement.LocalName)
                        {
                            case "call":
                                AddArrayNamespace(doc.SelectSingleNode("//args"));
                                break;
                        }
                    }
                    var ms = new MemoryStream();
                    XmlWriterSettings ws = new XmlWriterSettings
                    {
                        CloseOutput = false,
                    };
                    using (var xw = XmlWriter.Create(ms, ws))
                    {
                        doc.Save(xw);
                        xw.Flush();
                    }
                    Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
                    ms.Position = 0;
                    var xr = XmlReader.Create(ms);
                    newMessage = Message.CreateMessage(message.Version, null, xr);
                    newMessage.Headers.CopyHeadersFrom(message);
                    newMessage.Properties.CopyProperties(message.Properties);
                }
                return newMessage;
            }
        }
        [ServiceContract(Namespace = "")]
        public interface ITest
        {
            [OperationContract(Action = "urn:Mage_Api_Model_Server_HandlerAction")]
            int call(string args);
        }
        public class Service : ITest
        {
            public int call(string args)
            {
                return int.Parse(args);
            }
        }
        class MyBehavior : IOperationBehavior
        {
            public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
            {
            }
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            {
                clientOperation.Formatter = new GetOrdersMessageFormatter(clientOperation.Formatter);
            }
            public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
            }
            public void Validate(OperationDescription operationDescription)
            {
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), new BasicHttpBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            foreach (OperationDescription operation in factory.Endpoint.Contract.Operations)
            {
                operation.Behaviors.Add(new MyBehavior());
            }
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.call("4455"));
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
