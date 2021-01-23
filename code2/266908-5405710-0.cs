    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    
    namespace WCFServiceExample
    {
    
        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
    
        }
    
        [ServiceContract(Namespace = "")]
        public interface IProductService
        {
            [WebGet(UriTemplate = "Product/{id}", ResponseFormat = WebMessageFormat.Json)]
            [OperationContract]
            Product Product(string id);
    
        }
        public class ProductService : IProductService
        {
    
            public Product Product(string id)
            {
                return new Product { Id = id, Name = "A Sample Product" }; 
            }
        }
    
        class Program
        {
            private static ServiceHost servHost;
            static void Main(string[] args)
            {
                StartService();
                Console.WriteLine("\n\nPress any key to exit...");
                Console.ReadKey();
            }
    
            public static void StartService()
            {
                servHost = new ServiceHost(typeof(ProductService));
                servHost.Open();
            }
    
            ~Program()
            {
                if (servHost != null)
                {
                    servHost.Close();
                }
            }
        }
    }
