    public static void Main(string[] args)
    {
        List<int> outerList = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            outerList.Add(i);
        }
        List<List<int>> innerLists = new List<List<int>>();
        for (int i = 0; i < 5; i++)
        {
            innerLists.Add(new List<int>());
        }
        for (int i = 0; i < outerList.Count; i++)
        {
            innerLists[i % 5].Add(outerList[i]);
        }
        Console.WriteLine("outer List:");
        foreach (int i in outerList)
        {
            Console.Write($" { i } ");
        }
        Console.WriteLine();
        Console.WriteLine("inner List:");
        foreach (List<int> l in innerLists)
        {
            foreach (int i in l)
            {
                Console.Write($" { i } ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.Read();
    }
