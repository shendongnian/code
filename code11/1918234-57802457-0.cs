    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = "[{\"Id\":5002,\"Name\":\"Test Recipe\"}]";
                string data2 = "{\"Id\":5002,\"Name\":\"Test Recipe\"}";
    
                //This throws an exception
                //DataClass account = JsonConvert.DeserializeObject<DataClass>(data);
    
                //This works
                DataClass account2 = JsonConvert.DeserializeObject<DataClass>(data2);
    
                //This also works
                DataClass[] account3 = JsonConvert.DeserializeObject<DataClass[]>(data);
            }
        }
    
        class DataClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
