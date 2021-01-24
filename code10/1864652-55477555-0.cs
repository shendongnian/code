    public class Program
    {
      public class MappedObject
      {
        public string Name { get; set; }
        public string Type { get; set; }
      }
    
      public static void Main(string[] args)
      {
        // search query
        string searchFor = "Name1";
        // our json
        string jsonData = "[{\"Name\": \"Name1\",\"Type\": \"TypeA\"},{\"Name\": \"Name2\",\"Type\": \"TypeB\"}]";
        // I'm mapping the json string into a list of MappedObject (s)
        List<MappedObject> mappedObjects = JsonConvert.DeserializeObject<List<MappedObject>>(jsonData);
    
        // I'm looping through this list to find the MappedObject
        // that matches the searchFor search query string
        foreach (MappedObject obj in mappedObjects)
        {
          if (obj.Name == searchFor)
          {
            // when I find it, I'll print the Type property
            Console.WriteLine(obj.Type);
          }
        }
    
        Console.ReadLine();
      }
    }
