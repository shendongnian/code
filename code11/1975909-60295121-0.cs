using System;
using NCalc;
				
public class Program
{
	public static void Main()
	{
        Expression e = new Expression("!((71 > 70) && (80 > 71)) || 72 < 71");
        bool v = (bool)e.Evaluate();
		Console.WriteLine(v.ToString());
	}
}
.Net Fiddle: https://dotnetfiddle.net/02c5ww
