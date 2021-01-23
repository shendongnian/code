    Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();    
        d.Add("cat", new List<string> {"2", "2"});    
        d.Add("dog", new List<string> {"10", "A"});    
        d.Add("llama", new List<string>{"A","B"});    
        d.Add("iguana", new List<string>{"-2","-3"});    
  
    List<List<string>> values = d.Values.AsQueryable().ToList();    
    int count = values[0].Count;    
    for (int i = 0; i < count; i++)   
    {  
        for (int j = 0; j < values.Count; j++)  
        {    
            Console.Write(values[j].ElementAt(i));  
        }    
    }  
  
