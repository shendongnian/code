    List<string> items = new List<string>(obj2.Stuff);
    for (int i = 0; i < 5000; i++) {
      items.Add("Iteration " + i.ToString());
    }
    obj2.Stuff = items.ToArray();
