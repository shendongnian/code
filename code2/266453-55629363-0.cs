    int size = 1000000;
    var list1 = new List<int>();
    var list2 = new List<int>();
    
    for (int i = 0; i < size; i++)
    {
        list1.Add(i);
        list2.Add(i);
    }
    
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < size; i++)
    {
        list1.RemoveAt(size-1);
        list1.Add(0);
    }
    sw.Stop();
    Console.WriteLine("Time elapsed: {0}", sw.ElapsedMilliseconds);
    
    sw = Stopwatch.StartNew();
    for (int i = 0; i < size; i++)
    {
        list2.RemoveAt(0);
        list2.Add(0);
    }
    sw.Stop();
    
    Console.WriteLine("Time elapsed: {0}", sw.ElapsedMilliseconds);
