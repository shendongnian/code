      class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("net.tcp://10.157.13.69:5566");
            NetTcpBinding binding = new NetTcpBinding();
            ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress(uri));
            factory.Credentials.Windows.ClientCredential.UserName = "administrator";
            factory.Credentials.Windows.ClientCredential.Password = "abcd1234!";
            IService service = factory.CreateChannel();
            try
            {
                var result = service.Test();
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Test();
    }
