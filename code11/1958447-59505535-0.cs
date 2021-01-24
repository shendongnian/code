csharp
using System;
					
public class Program
{
	public static void Main()
	{
		var x = new X(10);
		var doubleX = AbstractVectorProcessor.Add(x, x);
		Console.WriteLine(doubleX.Value);
	}
	
	public interface IAdd<T>
	{
		T Add(T b);
	}
	
	public struct X : IAdd<X>
	{
		public X(double val)
		{
			Value = val;
		}
		
		public double Value {get;}
		
		public X Add(X b)
		{
		    return new X(Value + b.Value);
		}
	}
	
	public struct Y : IAdd<Y>
	{
		public Y(double val)
		{
			Value = val;
		}
		
		public double Value {get;}
		
	    public Y Add(Y b)
		{
		    return new Y(Value + b.Value);
		}
	}
	
	public static class AbstractVectorProcessor
	{
		public static T Add<T>(T a, T b) where T : IAdd<T>
		{
		    return a.Add(b);	
		}
	}
}
