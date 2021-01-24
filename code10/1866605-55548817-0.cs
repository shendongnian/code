    public static void DoSomething(int x)
    {
        Console.WriteLine("Starting " + x);
        Thread.Sleep((x%10) * 1000);
    }
    
    public static void Main(string[] args)
    {
    
        Queue<int> myList = new Queue<int>();
        for (int i = 0; i < 100; i++)
            myList.Enqueue(i);
    
        // This would be random if we'd use a List
        //Parallel.ForEach(myList, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, x => DoSomething(x));
    
        // This will get the right order. But 2 can still be faster than 1 if 2's thread is quicker. But generally you got your order.
        Parallel.For(
            0,  // We count from 0
            myList.Count,  // to max entries..
            new ParallelOptions() { MaxDegreeOfParallelism = 4 },  // don't forget this one ;)
            (x) => { int y = myList.Dequeue(); Console.WriteLine(y); DoSomething(y); }); // Dequeue from Queue and throw item into your function.
    }
