    class RemoteDatabase
    {
    	public int GetCommand(){return 5;}
    }
    
    class Program
    {
    
    	static void Main(string[] args)
    	{
    		var rd = new RemoteDatabase();
    		// Overloaded(1, rd.GetCommand); // this is a compile error, ambigous
    
    		Overloaded(1, () => rd.GetCommand()); // this compiles and works
 
    		Console.ReadLine();
    	}
    
    	static void Overloaded(int paramOne, Func<int> paramFun)
    	{
    		Console.WriteLine("First {0} {1}", paramOne, paramFun());
    	}
    
    	static void Overloaded(int paramOne, Func<string> paramFun)
    	{
    		Console.WriteLine("Second {0} {1}", paramOne, paramFun());
    	}
    }
