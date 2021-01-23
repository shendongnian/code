    List<object> AllResults = new List<object>();
    
    foreach(string word in words) 
    {
      var temp = word;
      AllResults.AddRange (result.Where(x => x.subject.Contains(temp)).ToList());
    }
