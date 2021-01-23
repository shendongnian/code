    static Dictionary<string, string> dict = new Dictionary<string, string>();
    static void Main(string[] args)
    {
        string message = "test of mine";
        string[] keys = new string[] {"test2",  "test"  };
       
        // this happens only once, during intialization, this is just sample code
        dict.Add("test", "yes");
        dict.Add("test2", "yes2"); 
     
        string sKeyResult = keys.FirstOrDefault<string>(s=>message.Contains(s));
        Console.WriteLine(dict[sKeyResult]); //or `TryGetValue`... 
     }
