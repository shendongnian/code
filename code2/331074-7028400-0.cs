    interface IA
    	{
    	}
    
    	class A : IA
    	{
    	}
    
    	interface IFoo<T> where T : IA
    	{
    	}
    
    	class Foo<T> : IFoo<T> where T : IA
    	{
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			IFoo<A> fooA = new Foo<A>();
    			Foo<IA> fooIa = fooA as Foo<IA>;
    		}
    	}
