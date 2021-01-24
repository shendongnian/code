    static Random random = new Random();
    public class CompareObject
    {
    	public string prop { get; private set; }
    	public CompareObject()
    	{
    		prop = random.Next(0, 1000000).ToString();
    	}
    
    	public new int GetHashCode() {
    		return prop.GetHashCode();
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
    	var sourceHashtable = new Hashtable();
    	var targetHashtable = new Hashtable();
    
    	foreach (var element in targetList)
    	{
    		var hash = element.GetHashCode();
    		if (!targetHashtable.ContainsKey(hash))
    			targetHashtable.Add(element.GetHashCode(), element);
    	}
    
    	var result = new List<CompareObject>();
    	foreach (var element in sourceList)
    	{
    		var hash = element.GetHashCode();
    		if (!sourceHashtable.ContainsKey(hash))
    		{
    			sourceHashtable.Add(hash, element);
    			if(!targetHashtable.ContainsKey(hash)) {
    				result.Add(element);
    			}
    		}
    	}
    	
    	stopWatch.Stop();
    
    	Console.WriteLine(stopWatch.Elapsed);
    }
