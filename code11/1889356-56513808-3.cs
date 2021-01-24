    public class Rootobject
    {
    	public Class1[] Property1 { get; set; }
    }
    
    public class Class1
    {
    	public string Attr1 { get; set; }
    	public string Attr2 { get; set; }
    	public B B { get; set; }
    }
    
    public class B
    {
    	public string Attr1 { get; set; }
    	public string Attr2 { get; set; }
    	public C C { get; set; }
    }
    
    public class C
    {
    	public string Attr1 { get; set; }
    	public string Attr2 { get; set; }
    }
