    void Main()
    {
    	var test = new tester() { val = "123" };
    	var changeTest = new ObjectHasChanged<tester>(test,t=>t.val);
    	
    	changeTest.HasChanged.Dump(); //false
    	
    	test.val = "321";
    	
    	changeTest.HasChanged.Dump(); //true
    }
    public class tester
    {
    	public string val { get; set; }
    }
    public class ObjectHasChanged<T>
    {
    	public bool HasChanged
    	{
    		get
    		{
    			return !this.initvalue.Equals(this.valueExpression(this.obj));
    		}
    	}
    	private object initvalue {get; set;}
    	private Func<T,object> valueExpression { get; set; }
    	private T obj { get; set; }
    	public ObjectHasChanged(T obj, Func<T,object> valueExpression)
    	{
    		this.obj = obj;
    		this.valueExpression = valueExpression;
    		this.initvalue = valueExpression(this.obj);
    	}
    }
