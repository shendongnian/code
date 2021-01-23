    List<String> listWithDynamic = new List<String>();
    for (int i = 1; i < limit; i +=1)
    {
        listWithDynamic.Add(string.Format("track_{0}", i));
        ...
    }
