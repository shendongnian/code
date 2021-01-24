    class Program
        {
            static void Main(string[] args)
            {
                NetTcpBinding binding = new NetTcpBinding()
                {
                    Security = new NetTcpSecurity
                    {
                        Mode = SecurityMode.None
                    },
                    MaxBufferPoolSize = 6553600,
                    MaxBufferSize = 6553600,
                    MaxReceivedMessageSize = 6553600,
                    MaxConnections = 1000,
                    ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
                    {
                        MaxArrayLength = 2147483647,
                        MaxBytesPerRead = 2147483647,
                        MaxDepth = 2147483647,
                        MaxNameTableCharCount = 2147483647,
                        MaxStringContentLength = 2147483647,
                    },
                };
                //replace it with your practical service address.
                Uri uri = new Uri("net.tcp://10.157.13.69:8004");
                ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress(uri));
                IService service = factory.CreateChannel();
                var result = service.Test();
                Console.WriteLine(result);
    
            }
    
        }
    
        //the service contract shared between the client-side and the server-side.
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string Test();
    
        }
