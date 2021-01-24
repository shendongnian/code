    var list1 = new List<Test1>(); // Population of lists is elided for brevity.
    var list2 = new List<Test2>();
    var dups =
        from item1 in list1
        join item2 in list2 on item1.ID equals item2.ID
        select item1.ID;
    list1.RemoveAll(item => dups.Contains(item.ID));
    list2.RemoveAll(item => dups.Contains(item.ID));
