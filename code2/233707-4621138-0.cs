    void Main()
    {
    var kewl = new X<C>(new C());
    kewl.FunnyMethod(); //calls C.DoJOB()
    
    var kewl2 = new X<B>(new B());
    kewl2.FunnyMethod(); // calls B.DoJOB()
    	
    }
    
    public class X <T> where T : A<T>
    {
    	private A<T> foo;
    
    	public X(A<T> concrete)
    	{
    		foo = concrete;
    	}
    	
    	public void FunnyMethod()
    	{
    		foo.DoJOB();
    	}
    }
    
    public abstract class A<T> where T : A<T>
    {
    	public abstract void DoJOB();
    }
    
    public class B : A<B>
    {
    	public override void DoJOB()
    	{
    		Console.WriteLine("B");
    	}
    }
    
    public class C : A<C>
    {
    	public override void DoJOB()
    	{
    		Console.WriteLine("C");
    	}
    }
