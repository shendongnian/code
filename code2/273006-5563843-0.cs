    void Main()
    {
	Random r = new Random();
	double d1 = r.NextDouble() / 3.0;
	double d2 = r.NextDouble() / 3.0;
	double d3 = 1.0 - d1 - d2;
	System.Console.WriteLine(d1);
	System.Console.WriteLine(d2);
	System.Console.WriteLine(d3);
	System.Console.WriteLine(d1 + d2 + d3);
    }
