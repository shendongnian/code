    void Main()
    {
    X kewl = new X(new C());
    kewl.FunnyMethod(); //calls C.DoJOB()
    
    kewl = new X(new B());
    kewl.FunnyMethod(); // calls B.DoJOB()
    	
    }
    
    public class X
    {
    	private A foo;
    
    	public X(A concrete)
    	{
    		foo = concrete;
    	}
    	
    	public void FunnyMethod()
    	{
    		foo.DoJOB();
    	}
    }
    
    public abstract class A
    {
    	public abstract void DoJOB();
    }
    
    public class B : A
    {
    	public override void DoJOB()
    	{
    		Console.WriteLine("B");
    	}
    }
    
    public class C : A
    {
    	public override void DoJOB()
    	{
    		Console.WriteLine("C");
    	}
    }
