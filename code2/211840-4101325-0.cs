    NameValueCollection col = new NameValueCollection();
    col.Add("red", "rouge");
    col.Add("green", "verde");
    col.Add("blue", "azul");
    
    // order the keys
    foreach (var item in col.AllKeys.OrderBy(k => k))
    {
        Console.WriteLine("{0}:{1}", item, col[item]);
    }
    
    // or convert it to a dictionary and get it as a SortedList
    var sortedList = new SortedList(col.AllKeys.ToDictionary(k => k, k => col[k]));
    for (int i = 0; i < sortedList.Count; i++)
    {
        Console.WriteLine("{0}:{1}", sortedList.GetKey(i), sortedList.GetByIndex(i));
    }
    
    // or as a SortedDictionary
    var sortedDict = new SortedDictionary<string, string>(col.AllKeys.ToDictionary(k => k, k => col[k]));
    foreach (var item in sortedDict)
    {
        Console.WriteLine("{0}:{1}", item.Key, item.Value);
    }
