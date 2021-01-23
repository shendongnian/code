    var list = new List<int>();
    // add any item to the list
    list.Add(5);
    list.Add(8);
    list.Add(12);
    // we can remove it easily as well
    list.Remove(5);
    foreach(var item in list)
    {
      Console.WriteLine(item);
    }
