    static void Main()
    {
    	get1().ToObservable(TaskPoolScheduler.Default).Subscribe(Print);
    	get2().ToObservable(TaskPoolScheduler.Default).Subscribe(Print);
    }
    
    static void Print(int i)
    {
    	Console.WriteLine(i);
    }
    
    static IEnumerable<int> get1()
    {
        while (true)
        {
            System.Threading.Thread.Sleep(1000);
            yield return 1;
        }
    }
    
    static IEnumerable<int> get2()
    {
        while (true)
        {
            System.Threading.Thread.Sleep(200);
            yield return 2;
        }
    }
