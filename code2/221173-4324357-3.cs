    var processed = ActiveDictionary.Values.Where(x=>x.Ready).ToArray();
    foreach(var item in processed)
    {
       ActiveDictionary.Remove(item);
       ProcessedDictionary.Add(item.Id, item);
    }
