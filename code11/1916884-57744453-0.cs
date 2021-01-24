    var fileInfos = new List<Dictionary<string, string>>();
    
    var newNameOldNamePairs1 = new Dictionary<string, string>() 
    { 
      { "some value string7", "some value string 1" },
      { "some value string9", "some value string 2" }
    }
    
    fileInfos.Add(newNameOldNamePairs1);
    
    var newNameOldNamePairs2 = new Dictionary<string, string>();
    newNameOldNamePairs2.Add("some value strin78", "some value string 34");
    newNameOldNamePairs2.Add("some value string12", "some value string 56");
    newNameOldNamePairs2.Add("some value string78", "some value string 12");
    
    fileInfos.Add(newNameOldNamePairs2);
    
    // Iterate over the collection of key value pairs
    foreach (var entry in fileInfos.SelectMany(dictionary => dictionary))
    {
      File.Move(entry.Key, entry.Value);           
    }
