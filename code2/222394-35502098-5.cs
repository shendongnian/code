    void Main()
    {
    	var f = 10000000;
    	var p = new Test[f];
    	
    	for(int i = 0; i < f; ++i)
    	{
    		p[i] = new Test();
    		p[i].Property = i % 2;
    	}
    	
    	var time = DateTime.Now;
    	p.Sum(k => k.Property);
    	Console.WriteLine(DateTime.Now - time);
    	
    	int x = 0;
    	time = DateTime.Now;
    	foreach(var item in p){
    		x += item.Property;
    	}
    	Console.WriteLine(DateTime.Now - time);
    	
    	x = 0;
    	time = DateTime.Now;
    	for(int i = 0, j = f; i < j; ++i){
    		x += p[i].Property;
    	}
    	Console.WriteLine(DateTime.Now - time);
    }
    
    class Test
    {
    	public int Property { get; set; }
    }
