    byte[] a = {1,2,3,4,4,2,3,4,2,5,3,4,4,2,6,3,4,5,3,3};
    List<byte[]> b = new List<byte[]>();
    for (int u=0; u<a.Count; u+=5)
    {
         b.Add(a.Skip(u).Take(5).ToArray());
    }
