        void Main()
    {
    	D test = new D();
    	test.a = new A();
    	test.a.b = new B();
    	test.a.b.c = new C();
    	test.a.b.c.text = "test";
    	
    	test.clever("a.b.c.text").Dump();
    	
    	test.list = new List<string>();
    	test.list.Add("1");
    	test.list.Add("2");
    	test.list.Add("3");
    	
    	test.clever("list^1").Dump();
    	
    	test.Dump();
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
    	public List<string> list { get; set; }
    	
    	public object clever(string properties)
    	{
    		return getvalues(this,properties);
    	}
    	private object getvalues(object o,string Properties)
    	{
    
    		var properties = Properties.Split('.');
    		var indexsplit = properties[0].Split('^');
    		
    		var current = indexsplit[0];
    	
    
    		var prop = (from p  in o.GetType().GetProperties() where p.Name == current select p).Take(1).Single();
    		var val = prop.GetValue(o,null);
    		
    		if(indexsplit.Length>1)
    		{
    			var index = int.Parse(indexsplit[1]);
    			IList ival = (IList)val;
    			val = ival[index];
    		}
    		
    		if(properties[0] == Properties)
    			return val;
    		else
    			return getvalues(val,Properties.Replace(properties[0]+".",""));
    	}
    }
