    void Main()
    {
    	LogicBase a = new ClassA();
    	a.CommonMethod();
    
    	Console.WriteLine("----------------------------");
    
    	LogicBase b = new ClassB();
    	b.CommonMethod();
    }
    
    public class LogicBase
    {
    	public void CommonMethod()
    	{
    		DoSomething_1();
    		DoSomething_2();
    		DoSomething_3();
    	}
    
    	protected virtual void DoSomething_1()
    	{
    		// Default behaviour 1
    		Console.WriteLine("DoSomething_1 - Hello from LogicBase");
    	}
    
    	protected virtual void DoSomething_2()
    	{
    		// Default behaviour 2
    		Console.WriteLine("DoSomething_2 - Hello from LogicBase");
    
    	}
    
    	protected virtual void DoSomething_3()
    	{
    		// Default behaviour 3
    		Console.WriteLine("DoSomething_3 - Hello from LogicBase");
    	}
    }
    
    public class ClassA : LogicBase
    {
    	protected override void DoSomething_2()
    	{
    		// Behaviour specific to ClassA
    		Console.WriteLine("DoSomething_2 - Hello from ClassA");
    	}
    }
    
    public class ClassB : LogicBase
    {
    	protected override void DoSomething_3()
    	{
    		// Behaviour specific to ClassB
    		Console.WriteLine("DoSomething_3 - Hello from ClassB");
    	}
    }
