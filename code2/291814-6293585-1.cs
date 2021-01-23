    public interface IBase { }
    public interface IChild : IBase { }
    
    public interface IFoo<out T> where T : IBase { }
    
    public static class FooExt
    {
        public static void DoSomething<TFoo>(this TFoo foo)     where TFoo : IFoo<IChild>
        {
            IFoo<IChild> bar = foo;
            //Added by Ashwani 
            ((IFoo<IChild>)foo).DoSomethingElse();//Will Complie
            foo.DoSomethingElseTotally(); //Will Complie
            
            //foo.DoSomethingElse();	// Doesn't compile -- why not?
            bar.DoSomethingElse();		// OK
            DoSomethingElse(foo);		// Also OK!
            
        }
        public static void DoSomethingElse(this IFoo<IBase> foo)
        {
        }
        //Another method with is actually defined for <T>
        public static void DoSomethingElseTotally<T>(this T foo) 
        { 
        }
