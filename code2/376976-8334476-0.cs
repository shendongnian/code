    var list1 = new List<String>();
    var list2 = new List<String>();
    var list3 = new List<String>();
    // get an IEnumerable that contains all lists
    var concatEnum = list1.Concat(list2).Concat(list3);
    // do everything you want...
    var myLinqResult = concatEnum.Select(item => item.ToLower()).ToArray();
