     public List<string> GetpathsById(List<long> id)
    {
    long[] aa = id.ToArray();
        long x;
    List<string> paths = new List<string>();
    for (int i = 0; i < id.Count; i++)
    {
        x = id[i];
        int temp = aa[i];
        Presentation press = context.Presentations.Where(m => m.PresId == temp).FirstOrDefault();
        paths.Add(press.FilePath);
    }
    return paths;
    }
