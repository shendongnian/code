    List<string> foo = new List<string>() { "Hello", "World" };
    
    string serialized = JsonConvert.SerializeObject(foo);
    
    List<string> bar = JsonConvert.DeserializeObject<List<string>>(serialized);
    
    foreach (string s in bar)
    {
      Console.WriteLine(s);
    }
