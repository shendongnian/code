    class Data
      {
        public long? Id { get; set; }
        public string Gid { get; set; }
        public string Name { get; set; }
        public string Resource_Type { get; set; }
      }
      class Program
      {
        static void Main(string[] args)
        {
    
          string assignee = "{\"id\": 15247055788906, \"gid\": \"15247055788906\", \"name\": \"Bo Sundahl\", \"resource_type\": \"user\"}";
          Data data = JsonConvert.DeserializeObject<Data>(assignee);
          Console.WriteLine(data.Id);
          Console.WriteLine(data.Gid);
          Console.WriteLine(data.Name);
          Console.WriteLine(data.Resource_Type);
          Console.ReadLine();
        }
      }
