    using System;
    class Program
    {
    	static Func<T,object> MakeFunc<T>()
    	{
    		return x => 23;
    	}
    	static Type GetReturnType<T>(Func<T,object> f)
    	{
    		return f(default(T)).GetType();
    	}
    	static void Main(string[] args)
    	{
    		Type t = GetReturnType(MakeFunc<string>());
    		Console.WriteLine(t);
    	}
    }
