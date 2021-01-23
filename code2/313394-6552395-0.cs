    class Program
    {
    	static void Main( string[] args )
    	{
    		Foo( 5, "one", "two", "three" );
    		Console.ReadLine();
    	}
    
    	static void Foo( int counter, params string[] parms )
    	{
    		if( counter <= 0 ) return;
    
    		foreach( var str in parms )
    		{
    			Console.WriteLine( str );
    		}
    
    		Foo( --counter, parms );
    	}
    }
