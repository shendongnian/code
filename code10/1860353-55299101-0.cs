    string json = File.ReadAllText(@"Path to your json");
    
    JArray jArray = JArray.Parse(json);
    
    Token token = jArray[0].ToObject<Token>();
    jArray.RemoveAt(0);
    RandomData[] tokenData = jArray.First.ToObject<RandomData[]>();
    
    //--------------------Print Data to Console-------------------
    
    Console.WriteLine(token.token + "\n");
    
    foreach (var item in tokenData)
    {
        Console.WriteLine("ts: " + item.ts);
        Console.WriteLine("id: " + item.id);
        Console.WriteLine("val: " + item.val + "\n");
    }
    
    Console.ReadLine();
    
