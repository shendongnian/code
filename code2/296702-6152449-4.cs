    public class X
    {
	    interface ITest { int x {get; } }
	    struct Test : ITest
	    {
		    public int x { get; set; }
	    }
	    public static void Main(string[] ss)
	    {
		    var t = new Test { x=42 };
		    ITest itf = t;
	    }
    }
