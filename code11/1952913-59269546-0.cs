C#
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
//https://www.c-sharpcorner.com/article/aspect-oriented-programming-in-c-sharp-using-dispatchproxy/
public class Program
{
	
	public static void Main()
	{
		var foo = new  Foo();
		var decoratedFoo = AspectDecorator<IFoo>.Create(foo);
		
		Console.WriteLine("\n\nClass:\n");
		foo.method1();
		foo.method2();
		foo.method3();
		
		Console.WriteLine("\n\nDecorated Class:\n");
		decoratedFoo.method1();
		decoratedFoo.method2();
		decoratedFoo.method3();
		
		
	}
}
public class Foo : IFoo{
        public void method1(){Console.WriteLine("> call method1");}
        public void method2(){Console.WriteLine("> call method2");}
        public void method3(){Console.WriteLine("> call method3");}
}
public interface IFoo{
	void method1();
	void method2();
	void method3();	
}
public class AspectDecorator<T> : DispatchProxy 
{
    private T _impl;
    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
		Console.WriteLine($"Before : {targetMethod.Name}");
        var obj =  _impl.GetType().GetMethod(targetMethod.Name).Invoke(_impl, args);
		Console.WriteLine($"After : {targetMethod.Name}");
		return obj;
    }
	public void SetTarget(T target)
    {
        this._impl = target;
    }
	public static T Create(T decorated)
    {
        object proxy = Create<T, AspectDecorator<T>>();
		((AspectDecorator<T>) proxy)._impl=decorated;
        return (T)proxy;
    }
}
  [1]: https://dzone.com/articles/aspect-oriented-programming-in-c-using-dispatchpro
