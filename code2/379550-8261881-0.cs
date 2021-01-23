    Dictionary<string, int> New = new Dictionary<string, int>();
    Dictionary<string, int> Existing = new Dictionary<string, int>();
    
    New.Add("A", 100);
    New.Add("B", 200);
    New.Add("Y", 300);
    New.Add("X", 400);
    
    
    Existing.Add("A", 1);
    Existing.Add("B", 2);
    Existing.Add("C", 3);
    Existing.Add("D", 4);
    Existing.Add("E", 5);
    Existing.Add("F", 6);
    Existing.Add("G", 7);
    Existing.Add("H", 8);
    
    var newStuff = New.Where(n => !Existing.ContainsKey(n.Key)).ToList();
    var updatedStuff = Existing.Where(e => New.ContainsKey(e.Key) && e.Value != New.Single(n => n.Key == e.Key).Value);
    
    
    newStuff.Dump();
    updatedStuff.Dump();
    
    //updated and new 
    newStuff.AddRange(updatedStuff);
    newStuff.Dump();
