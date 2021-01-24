using System;
using DryIoc;
					
public class Program
{
	class A {}
	class B {}
	
	enum UIScope { Browser, Tab } 
	
	public static void Main()
	{
var container = new Container(r => r.WithUseInterpretation());
container.Register<A>(Reuse.ScopedTo(UIScope.Browser));
container.Register<B>(Reuse.ScopedTo(UIScope.Tab));
using (var browserScope = container.OpenScope(UIScope.Browser))
{
	A a1, a2;
    using (var tabScope1 = browserScope.OpenScope(UIScope.Tab))
    {
        a1 = tabScope1.Resolve<A>();
        var b1 = tabScope1.Resolve<B>();
    }
    using (var tabScope2 = browserScope.OpenScope(UIScope.Tab))
    {
        a2 = tabScope2.Resolve<A>();
        var b2 = tabScope2.Resolve<B>();
    }
	
	Console.WriteLine(a1 == a2);
}
}
}
