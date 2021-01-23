    var orderedDictionary = new OrderedDictionary();
    orderedDictionary.Add("1", new List<int> { 1, 2 });
    
    var newDictionary = new OrderedDictionary();
    foreach(DictionaryEntry de in orderedDictionary)
    {
    	newDictionary.Add(de.Key, de.Value);
    }
