	class Program
	{
	    static void Main(string[] args)
	    {
	        Action Execute = delegate { };
	
	        ProgramTest prog = new ProgramTest(h => Execute += h);
	
	        prog.AddMethod();
	
	        Execute();
	    }
	}
	
	class ProgramTest
	{
	    public Action<Action> execute;
	
	    public ProgramTest(Action<Action> action)
	    {
	        execute = action;
	    }
	
	    public void AddMethod()
	    {
	        execute(Print);
	    }
	
	    public void Print()
	    {
	        Console.WriteLine("test");
	        Console.ReadLine();
	    }
	}
