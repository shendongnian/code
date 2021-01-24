    var dictionary = people1.ToDictionary(x => x.Id, x => x);
    
    foreach(var person in people2)
    {
        if(!dictionary.ContainsKey(item.Id))
        {
            dictionary.Add(item.Id, item);
        }
    }
