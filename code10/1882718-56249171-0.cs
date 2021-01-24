    //how NOT to store multiple values under one key
    var dict = new Dictionary<string, string>();
    dict.Add("ch", "one");
    dict.Add("ch", "two"); //duplicate key exception
    dict["ch"] = "two"; //replaces "one" 
    //how to store multiple values under one key
    var dict = new Dictionary<string, List<string>>();
    if(!dict.ContainsKey("ch"))
      dict.Add("ch", new List<string>());
   
    dict["ch"].Add("one"); //get the list, Add "one" to the list, not the dictionary 
    dict["ch"].Add("two"); 
