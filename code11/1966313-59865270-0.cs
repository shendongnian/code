    public class Test
    {
    	public void Method1( params int[] nums )
    	{
    		nums.ToList().ForEach( n => Console.WriteLine(n) );
    	}
    	
    	public void Method2( List<int> nums )
    	{
    		nums.ForEach( n  => Console.WriteLine(n) );
    	}	
    }
    void Main()
    {	
    	var t = new Test();
    	t.Method1( 1, 2, 3, 4 );
    	t.Method2( new List<int>() { 1, 2, 3, 4 } );
    }
