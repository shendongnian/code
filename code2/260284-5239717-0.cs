    class ReflectClass1
    {
    	public ReflectClass1(Random rand)
    	{
    		Prop1 = rand.Next();
    		Prop2 = rand.Next();
    		Prop3 = rand.Next();
    		Prop4 = rand.Next();
    		Prop5 = rand.Next();
    		Prop6 = rand.Next();
    		Prop7 = rand.Next();
    		Prop8 = rand.Next();
    		Prop9 = rand.Next();
    		Prop10 = rand.Next();
    	}
    
    	public int Prop1 {get;set;}
    	public int Prop2 { get; set; }
    	public int Prop3 { get; set; }
    	public int Prop4 { get; set; }
    	public int Prop5 { get; set; }
    	public int Prop6 { get; set; }
    	public int Prop7 { get; set; }
    	public int Prop8 { get; set; }
    	public int Prop9 { get; set; }
    	public int Prop10 { get; set; }
    }
    
    class Program
    {
    	private static Random random = new Random((int)DateTime.Now.Ticks);
    	private Dictionary<string, Delegate> delegateList = new Dictionary<string, Delegate>();
    	private static int Iterations = 1000000;
    
    	private void TestMethod2<T>()	
    	{
    		foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
    		{
    			Func<T, int> getPropDelegate = (Func<T, int>) Delegate.CreateDelegate(typeof (Func<T, int>), null, propertyInfo.GetGetMethod());
    			delegateList.Add(propertyInfo.Name, getPropDelegate);
    		}
    	}
    
    	private void UseDelegateList()
    	{
    		//setup delegateList
    		TestMethod2<ReflectClass1>();
    
    		Stopwatch sw = Stopwatch.StartNew();
    
    		ReflectClass1 testClass = new ReflectClass1(random);
    		int total = 0;
    		for (int i = 0; i < Iterations; i++)
    		{
    			foreach (PropertyInfo propertyInfo in typeof(ReflectClass1).GetProperties())
    			{
    				if (delegateList.ContainsKey(propertyInfo.Name))
    				{
    					Func<ReflectClass1, int> getPropDelegate = (Func<ReflectClass1, int>) delegateList[propertyInfo.Name];
    					total += getPropDelegate(testClass);
    				}
    			}
    		}
    		
    
    		Console.WriteLine(string.Format(" End delegate performance test. iterations = {0:N0} end time: {1:0.000}", Iterations, sw.ElapsedMilliseconds / 1000.0));
    		Console.WriteLine(total);
    	}
    
    	private void UseDirectReflection()
    	{
    		Stopwatch sw = Stopwatch.StartNew();
    
    		int total = 0;
    		ReflectClass1 testClass = new ReflectClass1(random);
    		for (int i = 0; i < Iterations; i++)
    		{
    			foreach (PropertyInfo propertyInfo in typeof(ReflectClass1).GetProperties())
    			{
    				if (propertyInfo == null)
    					continue;
    				
    				total += (int)propertyInfo.GetValue(testClass, null);
    			}
    		}
    
    		Console.WriteLine(string.Format(" End direct reflection performance test. iterations = {0:N0} end time: {1:0.000}", Iterations, sw.ElapsedMilliseconds / 1000.0));
    		Console.WriteLine(total);
    	}
    
    	private void DirectOutputTest()
    	{
    		Stopwatch sw = Stopwatch.StartNew();
    
    		int total = 0;
    		ReflectClass1 testClass = new ReflectClass1(random);
    		for (int i = 0; i < Iterations; i++)
    		{
    			total += testClass.Prop1;
    			total += testClass.Prop2;
    			total += testClass.Prop3;
    			total += testClass.Prop4;
    			total += testClass.Prop5;
    			total += testClass.Prop6;
    			total += testClass.Prop7;
    			total += testClass.Prop8;
    			total += testClass.Prop9;
    			total += testClass.Prop10;
    		}
    		
    		
    		Console.WriteLine(string.Format(" End direct output benchmark. iterations = {0:N0} end time: {1:0.000}", Iterations, sw.ElapsedMilliseconds / 1000.0));
    		Console.WriteLine(total);
    	}
    
    	static void Main(string[] args)
    	{
    		var test = new Program();
    
    		test.UseDelegateList();
    		test.UseDirectReflection();
    		test.DirectOutputTest();
    		Console.Write("doe");
    	}
    }
