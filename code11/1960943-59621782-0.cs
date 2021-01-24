    class Program
    {
    	private static List<BaseScript> ListOfScrpits { get; set; }
    
    	static void Main(string[] args)
    	{
    		ServiceProvider serviceProvider = new ServiceCollection()
    			.AddTransient<BaseScript, DoThis>()
    			.AddTransient<BaseScript, DoThis>()
    			.AddTransient<BaseScript, DoSomethingElse>()
    			.BuildServiceProvider();
    
    		ListOfScrpits = serviceProvider.GetServices<BaseScript>().ToList();
    
    		foreach (BaseScript script in ListOfScrpits)
    			Console.WriteLine(script.GetType().Name);
    
    		Console.ReadLine();
    	}
    }
