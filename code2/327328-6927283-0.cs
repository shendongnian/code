    static void Main(string[] args)
    {
    	Stopwatch watch = new Stopwatch();
    	watch.Start();
    	List<Int32> test = GetList(500000);
    	watch.Stop(); Console.WriteLine(watch.Elapsed.ToString());
    	watch.Reset(); watch.Start();
    	test.RemoveAll( t=> t % 5 == 0);
    	List<String> test2 = test.ConvertAll(delegate(int i) { return i.ToString(); });
    	watch.Stop(); Console.WriteLine(watch.Elapsed.ToString());
    
    	Console.WriteLine((500000 - test.Count).ToString());
    	Console.ReadLine();
    
    }
    
    static private List<Int32> GetList(int size)
    {
    	List<Int32> test = new List<Int32>();
    	for (int i = 0; i < 500000; i++)
    		test.Add(i);
    	return test;
    }
