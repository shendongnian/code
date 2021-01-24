    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static readonly string endpointUrl = "https://***.documents.azure.com:443/";
            private static readonly string authorizationKey = "***";
            private static readonly string databaseId = "db";
            private static readonly string collectionId = "coll";
    
            private static DocumentClient client;
    
            static void Main(string[] args)
            {
                QueryTest();
                Console.ReadLine();
            }
    
    
            public static async void QueryTest()
    
            {
                client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
                var uri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
    
    
                Pojo pojo = new Pojo();
                pojo.name = "Name";
                pojo.Properties = new Properties();
                pojo.Properties.UserId = "123";
    
                RequestOptions request = new RequestOptions();
                request.PartitionKey = new PartitionKey("123");
    
                await client.CreateDocumentAsync(uri, pojo, request,false);
            }
        }
        class Pojo : Document
        {
            public Properties Properties { get; set; }
            public string name { get; set; }
        }
    
        class Properties
        {
    
            public string UserId { get; set; }
        }
    }
