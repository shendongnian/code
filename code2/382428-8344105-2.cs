    public class Program    {
    	class X { int x,y; }    
    	public static void Main(string[] args)
    	{
    		X a = new X();
    		X b = new X();
    		System.Console.WriteLine(a == b);
    		System.Console.WriteLine(a.Equals(b));
    		System.Console.WriteLine(Equals(a,b));
    		System.Console.WriteLine(ReferenceEquals(a,b));
    } }
