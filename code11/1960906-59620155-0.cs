using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		var factory = new DisposableFactory();
		IDisposable d;
		var success = factory.TryGetDisposable(out d);
		if (success){
			using (d) {
						
			}			
		}	
		
		using (factory.GetDisposableResults().Item2){
			
		}
	}	
}
public class CanDispose : IDisposable
{
	void IDisposable.Dispose(){
		
	}
}
public class DisposableFactory
{
	public bool TryGetDisposable(out IDisposable d)
	{
		d = new CanDispose();
		return true;
	}
	
	public (bool, IDisposable) GetDisposableResults()
	{
		var tup = (true, new CanDispose());
		return tup;
	}
}
