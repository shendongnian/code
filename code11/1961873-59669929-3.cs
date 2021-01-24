    static Random random = new Random();
    public class CompareObject
    {
    	public string prop { get; private set; }
    
    	public CompareObject()
    	{
    		prop = random.Next(0, 100000).ToString();
    	}
    
    	public new bool Equals(object o)
    	{
    		if (o.GetType() == typeof(CompareObject))
    			return this.prop == ((CompareObject)o).prop;	
    		return this.GetHashCode() == o.GetHashCode();
    	}
    }
    
    void Main()
    {
    	var sourceList = new List<CompareObject>();
    	var targetList = new List<CompareObject>();
    	for (int i = 0; i < 10000000; i++)
    	{
    		sourceList.Add(new CompareObject());
    		targetList.Add(new CompareObject());
    	}
    
    	var stopWatch = new Stopwatch();
    
    	stopWatch.Start();
    	var result = sourceList.AsParallel().Where(s => !targetList.Any(t => t.Equals(s)));
    	
    
    	var lr = result.Skip(10000).Take(10000).ToList();
    	stopWatch.Stop();
    
    	Console.WriteLine(stopWatch.Elapsed);
    }
