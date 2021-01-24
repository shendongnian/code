    namespace ConsoleApp8
    {   
        class Program
        {
            static void Main(string[] args)
            {
                var serializerSettings = new JsonSerializerSettings()
                {
                    DateFormatString = "yyyy-MM-ddThh:mm:ssZ"
                };
    
                Console.WriteLine($"DateTime.Now: {JsonConvert.SerializeObject(DateTime.Now)}, DateTime.Now Kind: {DateTime.Now.Kind}");
                Console.WriteLine($"DateTime.UtcNow: {JsonConvert.SerializeObject(DateTime.UtcNow)}, DateTime.UtcNow Kind: {DateTime.UtcNow.Kind}");
                Console.WriteLine($"DateTime.Now with formatting: {JsonConvert.SerializeObject(DateTime.Now, serializerSettings)}, DateTime.Now Kind: {DateTime.Now.Kind}");
    
                Console.ReadLine();
            }
        }
    }
