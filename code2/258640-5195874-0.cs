    void Main()
    {
    	var x = new B();
    	x.M();
    }
    
    public interface I
    {
    	void M();
    }
    public class A : I
    {
    	public void M()
    	{
    		"A.M".Dump();
    	}
    }
    public class B : A
    {
    	public new void M()
    	{
    		"B.M".Dump();
    		base.M();
    	}
    }
