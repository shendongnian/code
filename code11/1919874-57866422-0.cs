    IList<int> differentIndices = new List<int>();
    for(int i=0;i<a.Count;i++)
    {
       if (a[i] ^ b[i])
       {
           differentIndices.Add(i);
       }
    }
