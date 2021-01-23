    HashSet<int> ids2=new HashSet<int>();
    foreach(var e in Table2)
    {
        ids2.Add(e.ID);
    }
    List<string> captionsOnlyInTable1=new List<string>();
    foreach(var e in Table1)
    {
        if(!ids2.Contains(e.ID))
            captionsOnlyInTable1.Add(e.Caption);
    }
