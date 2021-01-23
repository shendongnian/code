    List<int> list = new List<int> { 1, 2, 3 };
    // This cast is actually not needed; I'm just including it so that it mirrors
    // your example code.
    IList<int> ilist = (IList<int>)list;
    // Now we remove an item from the List<int> object referenced by list.
    list.Remove(3);
    // Is it in ilist? No--they are the same List<int> object.
    Console.WriteLine(ilist.Contains(3));
    // How about we remove an item using ilist, now?
    ilist.Remove(2);
    // Is it in list? Nope--same object.
    Console.WriteLine(list.Contains(2));
    // And here's one last thing to note: the type of a VARIABLE is not the same
    // as the type of the OBJECT it references. ilist may be typed as IList<int>,
    // but it points to an object that is truly a List<int>.
    Console.WriteLine(ilist.GetType());
