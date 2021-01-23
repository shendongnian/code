    List<int> list = new List<int>();
    var start = DateTime.Now;
    for (int i = 0; i < 50000000; i++) list.Add(i);
    for (int i = 0; i < 50000000; i++) list[i] = 0;
    var span = DateTime.Now - start;
    Console.WriteLine("List test,  ms: {0}", span.TotalMilliseconds);
    
    IList<int> ilist = new List<int>();
    start = DateTime.Now;
    for (int i = 0; i < 50000000; i++) ilist.Add(i);
    for (int i = 0; i < 50000000; i++) ilist[i] = 0;
    span = DateTime.Now - start;
    Console.WriteLine("IList test, ms: {0}", span.TotalMilliseconds);
