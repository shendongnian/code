      class Program
            {
                static void Main(string[] args)
                {
                    BasicHttpBinding binding = new BasicHttpBinding();
                    Uri uri = new Uri("http://10.157.13.69:3336");
                    ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress(uri));
                    IService service = factory.CreateChannel();
                    //without adding additional messsage header, generally invoke
                    service.WriteMessageHeader();
                    //add additional message header.
                    using (OperationContextScope scope=new OperationContextScope((IContextChannel)service))
                    {
                        //insert custom message header
                        OperationContext oc = OperationContext.Current;
                        MessageHeader mh = MessageHeader.CreateHeader("MyMessageHeaderName", "MyMessageHeaderNamespace", "myvaule");
                        oc.OutgoingMessageHeaders.Add(mh);
                        service.WriteMessageHeader();
                    }
                    Console.ReadLine();
        
                    
                    
                }
            }
            [ServiceContract]
            interface IService
            {
                [OperationContract]
                void WriteMessageHeader();
        }
