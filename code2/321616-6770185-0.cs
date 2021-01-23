    public class A
    {	
    }
    
    public class B : A
    {
    	public bool Visible { get; set; }
    }
    
    public class C : A
    {
    }
    
    void Main()
    {
    	var data = new List<A> { new A(), new B(), new C(), new B() };
    	
    	data.OfType<B>().ToList().ForEach(x => x.Visible = true);
    }
