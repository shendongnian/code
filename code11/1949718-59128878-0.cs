    class Image
    {
    
    }
    
    private static async Task Main(string[] args)
    {
    	var x = new int[30];
    	var images = new Image[30];
    	var result = new List<Image>();
    	var minYear = 1919;
    	var maxYear = 1925;
    
    	for (int i = 0; i < x.Length; i++)
    	{
    		if (x[i] <= maxYear && x[i] >= minYear)
    		{
    			result.Add(images[i]);
    		}
    	}
    	Console.WriteLine();
    }
