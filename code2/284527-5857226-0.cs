    List<int> l1 = new List<int>();
    List<int> l2 = new List<int>();
    
    l1.AddRange(new int[] {1, 2, 3, 5});
    l2.AddRange(new int[] {1, 2, 3, 4});
    
    // get only the objects that are in l2, but not l1
    var l3 = l2.Except(l1);
