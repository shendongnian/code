    class Program
    {
    	static void Main(string[] args)
    	{
    		var d = new Dummy(42);
    		Console.WriteLine(String.Format("{0}^2={1}", d, d.Squared())); // Fine!?
    		Console.WriteLine(String.Format("{0}^2={1}", d, Extensions.Squared2(d))); // COmplains as expected
    	}
    }
