    List<int> list = new List<int> { 1, 2, 3 };
    // This cast is actually not needed; I'm just including it so that it mirrors
    // your example code.
    IList<int> ilist = (IList<int>)list;
    // Now we remove an item from the object referenced by list.
    list.Remove(3);
    // Is it in ilist? No--they are the same object.
    Console.WriteLine(ilist.Contains(3));
    // How about we remove an item from ilist, now?
    ilist.Remove(2);
    // Is it in list? No--same object.
    Console.WriteLine(list.Contains(2));
