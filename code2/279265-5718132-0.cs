    List<string> list = obj2.Stuff.ToList();
    for (int i = 0; i < 5000; i++)
    {
         list.Add("Iteration " + i.ToString());
    }
