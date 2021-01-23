    public class Base
    {
    	public virtual T Foo<T>() where T : Base 
    	{ 
            //... // do stuff
            return (T)this; 
        }
    }
    
    public class A : Base
    {
    	public A Bar() { "Bar".Dump(); return this; }
    	public A Baz() { "Baz".Dump(); return this; }
    
    	// optionally override the base...
    	public override T Foo<T>() { "Foo".Dump(); return base.Foo<T>(); }
    }
    var x = new A()
        .Bar()
        .Foo<A>() // cast back to A
        .Baz();
