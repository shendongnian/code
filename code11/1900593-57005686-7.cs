    using Newtonsoft.Json;
    using System;
    
    namespace ConsoleApp11
    {
        class Program
        {
            public class CustomerJson
            {
                [JsonProperty("IdPostazionee")]
                public Customer Customer { get; set; }
            }
    
            public class Customer
            {
                [JsonProperty("abc")]
                public string Firstname { get; set; }
    
                [JsonProperty("def")]
                public string Lastname { get; set; }
    
            }
    
            static void Main(string[] args)
            {
                string json = "{'IdPostazione':'1','StatoAutoma':'2','OriginalURL':'3','OriginalTitle':'lol','ChronicID':'xd'}";
    
                dynamic dynObj = JsonConvert.DeserializeObject(json);
    
                Console.WriteLine("{0} {1} {2}", dynObj.IdPostazione, dynObj.StatoAutoma, dynObj.OriginalURL);
    
                string jsoon = "{'IdPostazionee': {'abc':'123','def':'456'}}";
    
                var customerJson = JsonConvert.DeserializeObject<CustomerJson>(jsoon);
    
                Console.WriteLine(customerJson.Customer.Firstname);
                Console.WriteLine(customerJson.Customer.Lastname);
            }
        }
    }
