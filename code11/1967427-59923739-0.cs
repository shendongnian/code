    public static void Main()
    {
       var list = new List<double>() { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
       List<List<double>> chunks = SplitList(list, 4);
    }
    public static List<List<T>> SplitList<T>(IList<T> source, int chunkSize)
    {
        List<List<T>> chunks = new List<List<T>>();
        for (int i = 0; i < source.Count; i += (chunkSize - 1))
        {
           chunks.Add(source.Skip(i).Take(chunkSize).ToList());
        }
        return chunks;
    }
