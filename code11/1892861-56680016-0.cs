        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("http://10.157.13.69:3336/mex");
                MetadataExchangeClient client = new MetadataExchangeClient(uri, MetadataExchangeClientMode.MetadataExchange);
                MetadataSet metadata = client.GetMetadata();
                WsdlImporter importer = new WsdlImporter(metadata);
                ServiceEndpointCollection endpoints = importer.ImportAllEndpoints();
    
                //ServiceEndpointCollection endpoints = MetadataResolver.Resolve(typeof(IService), uri, MetadataExchangeClientMode.MetadataExchange);
                foreach (var item in endpoints)
                {
                    Console.WriteLine(item.Address.Uri);
                }
            }
        }
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string SayHello();
    }
