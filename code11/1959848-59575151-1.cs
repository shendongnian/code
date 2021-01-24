       class Program
        {
            static void Main(string[] args)
            {
    //given that we have known the service information, binding type, service endpoint.
                Uri uri = new Uri("http://10.157.13.69:21011");
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.None;
                ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress(uri));
                IService service = factory.CreateChannel();
                var result = service.Test();
                Console.WriteLine(result);
            }
        }
    
        //service contract is shared between the client-side and the server-side.
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string Test();
        }
