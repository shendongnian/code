    var list1 = new List<string>() { "Test1", "Test2", "Test2", "Test3", "Test4" };
    var list2 = new List<string>() { "Test1", "Test2", "Test5", "Test6" };
    
    var newlist = new List<string>();
    list1.ForEach(delegate(string s) { if (!list2.Remove(s)) newlist.Add(s); });
    newlist = newlist.Concat(list2).ToList();
