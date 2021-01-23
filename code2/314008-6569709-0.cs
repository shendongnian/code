    struct Mutable
    {
    	private int x;
    	public int Mutate()
    	{
    		this.x = this.x + 1;
    		return this.x;
    	}
    }
    
    Mutable property{get;set;}
    
    void Main()
    {
    	property=new Mutable();
    	property.Mutate().Dump();//returns 1
    	property.Mutate().Dump();//returns 1 :(
    }
