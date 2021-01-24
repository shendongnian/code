    public class MyObject
    {
    	public char Modifier { get; set; }
    	public string Name { get; set; }
    	public string Type { get; set; }
    	
    	public static IEnumerable<MyObject> Parse(string str)
    	{
    		return str
    		.Split(' ')
    		.Where(s => string.IsNullOrEmpty(s) == false)
    		.ToList()
    		.ForEach(i =>
    		{
    			var sections = i.Remove(0, 1).Split(':');
    			return new MyObject()
    			{
    				Modifier = i[0],
    				Name = sections[0],
    				Type = sections[1]
    			};
    		});
    	}
    }
