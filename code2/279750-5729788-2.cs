    public delegate void ParamLess();
    class SomeClass
    {
    	public void PrintStuff()
    	{
    		Console.WriteLine("stuff");
    	}
    }
    internal class Program
    {
    	private static Dictionary<int, int> dict = null;
    	static void Main()
    	{
    		var obj = new SomeClass();
    		Delegate del = Delegate.CreateDelegate(typeof(ParamLess), obj, 
                    "PrintStuff", false);
    		del.DynamicInvoke(); // invokes SomeClass.PrintStuff, which prints "stuff"
    	}
    }
