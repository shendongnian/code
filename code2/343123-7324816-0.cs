    var dictionary = new Dictionary<string, SomeClassName>();
    var name = "member-";
  
    for(int i = 0; i < 5; i++)
    {
        dictionary[name+i.ToString()] = new SomeClassName();
    }
