    void Main()
    {
    	D test = new D();
    	test.a = new A();
    	test.a.b = new B();
    	test.a.b.c = new C();
    	test.a.b.c.text = "test";
    	test.Dump();
    	test.clever("a.b.c.text").Dump();
    }
    
    public class A
    {
    	public B b { get; set; }
    }
    public class B
    {
    	public C c { get; set; }
    }
    public class C
    {
    	public string text { get; set; }
    }
    public class D
    {
    	public A a { get; set; }
    	
    	public object clever(string properties)
    	{
    		return getvalues(this,properties);
    	}
    	private object getvalues(object o,string Properties)
    	{
    		var properties = Properties.Split('.');
    		var current = properties[0];
    		var prop = (from p  in o.GetType().GetProperties() where p.Name == current select p).Take(1).Single();
    		var val = prop.GetValue(o,null);
    		if(current == Properties)
    			return val;
    		else
    			return getvalues(val,Properties.Replace(current+".",""));
    	}
    }
