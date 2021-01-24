    class Coordinates
    {
    	public Coordinates(int x, int y)
    	{
    		X = x;
    		Y = y;
    	}
    
    	private int _x;
    	public int X
    	{
    		get { return _x; }
    		set { _x = value * 10; }
    	}
    
    	private int _y;
    	public int Y
    	{
    		get { return _y; }
    		set { _y = value * 10; }
    	}
    }
