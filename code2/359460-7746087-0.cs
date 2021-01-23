    class MyTuple : Tuple<int, int>
    {
    	public MyTuple(int one, int two)
    		:base(one, two)
    	{
    
    	}
    	
    	public int OrderGroupId { get{ return this.Item1; } }
    	public int OrderTypeId { get{ return this.Item2; } }
    
    }
