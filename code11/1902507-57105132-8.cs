    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("net.tcp://vabqia969vm:5566");
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, new EndpointAddress(uri));
            factory.Credentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, "9ee8be61d875bd6e1108c98b590386d0a489a9ca");
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
