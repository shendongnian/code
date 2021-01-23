    List<string> list1 = new List<string>() { "Test1", "Test2", "Test2", "Test3", "Test4" };
    List<string> list2 = new List<string>() { "Test1", "Test2", "Test5", "Test6" };
    
    var newlist = new List<string>();
    list1.ForEach(delegate(string s) { if (!list2.Remove(s)) newlist.Add(s); });
    list2.ForEach(delegate(string s) { if (!newlist.Remove(s)) newlist.Add(s); });
