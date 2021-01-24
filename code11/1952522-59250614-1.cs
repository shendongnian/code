    var list1 = new List<List1>();
    list1.Add(new List1() { StudentCode = "s1", Department = "d1" });
    list1.Add(new List1() { StudentCode = "s2", Department = "d2" });
    list1.Add(new List1() { StudentCode = "s3", Department = "d3" });
            
    var listInfo = new List<ListInfo>();
    listInfo.Add(new ListInfo() { StudentCode = "s1" });
    listInfo.Add(new ListInfo() { StudentCode = "s3" });
    var list2 = new List<List2>();
    list2.Add(new List2() { id = "1", ListInfo = listInfo });     
    var filteredlist = list1.Where(x => list2.Any(l2=>l2.ListInfo.Any(y => y.StudentCode == x.StudentCode)));
