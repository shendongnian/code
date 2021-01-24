    void Main()
    {	
    	Do();
    }
    
    public async Task Do()
    {    
    	List<Product> products = new List<UserQuery.Product>
    	{
    		new Product(),
    		new Product(),
    		new Product(),
    		new Product(),
    	};
    	Stopwatch sw = new Stopwatch();
    	Console.WriteLine("START");
    	sw.Start();
    	await Task.WhenAll(products.Select(async x => x.MyProperty = await GetNumber()));
    	sw.Stop();
    	Console.WriteLine($"ENDE: {sw.ElapsedMilliseconds}");    	
    	products.Dump();    
    }
    
    public async Task<int> GetNumber()
    {
    	Random rand = new Random(DateTime.Now.Millisecond);
    	return await Task.Run(() => { System.Threading.Thread.Sleep(4000); return rand.Next(1,1000);});
    }
    
    class Product
    {
    	public int MyProperty { get; set; }
    }
