using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
					
public class Program
{
	public static void Main()
	{
		var values = new List<string> { "some", "input", "values" };
		var input1 = "this does not have any match";
		Console.WriteLine("Input1 contains some match? " + values.Any(v => input1.Contains(v)));
		
		var input2 = "this does have some match";
		Console.WriteLine("Input2 contains some match? " + values.Any(v => input2.Contains(v)));
	}
}
