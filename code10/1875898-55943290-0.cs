    public class A { }
    public class B<T>{}
    public static class Extensions
    {
    	public static void DoSomething<T>(this B<T> thing) {}
    }
    
    public static void Test()
    {
    	var test = new B<A>();
    
    	test.DoSomething();
    }
