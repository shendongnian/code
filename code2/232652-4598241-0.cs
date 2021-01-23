    Dictionary<string,List<string>> dict; // given
    
    foreach(var kvp in dict)
    {
      Console.WriteLine(string.Format("{0}: {1}",
        kvp.Key, kvp.Value.Aggregate((c,n)=>c+=','+n)));
    }
