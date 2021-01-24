c#
using System;
					
public class Program
{
	enum eOperator
	{
		opAdd = 0,
		opSub = 1,
		opDiv = 2,
		opMul = 3,
		opInvalid = int.MinValue + 1,
		opQuit = int.MinValue
	}
	public static void Main()
	{
		double a = 0.0, b = 0.0;
		eOperator op = eOperator.opQuit;
		string input = String.Empty;
		Console.WriteLine("Calculator");
		Console.WriteLine("Enter 'quit' at any time to exit.");
		do
		{
			Console.Write("a = ");
			input = Console.ReadLine().ToLower().Trim();
			if (double.TryParse(input, out a))
			{
				Console.Write("Operator: ");
				input = Console.ReadLine().ToLower().Trim();
				switch (input)
				{
					case "+":
						op = eOperator.opAdd;
						break;
					case "-":
						op = eOperator.opSub;
						break;
					case "*":
						op = eOperator.opMul;
						break;
					case "/":
						op = eOperator.opDiv;
						break;
					case "quit":
						op = eOperator.opQuit;
						break;
					default:
						op = eOperator.opInvalid; // can't be left as quit
						Console.WriteLine("Invalid entry. +, -, *, / or quit for operator.");
						break;
				}
				if (op != eOperator.opQuit && op != eOperator.opInvalid)
				{
					Console.Write("b = ");
					input = Console.ReadLine().ToLower().Trim();
					if (double.TryParse(input, out b))
					{
						double result = a;
						switch (op)
						{
							case eOperator.opAdd:
								result += b;
								break;
							case eOperator.opSub:
								result -= b;
								break;
							case eOperator.opMul:
								result *= b;
								break;
							case eOperator.opDiv:
								// Div by 0 check. without this, this still works since double has +/- inf values.
								if (b != 0.0) // comparing double with = and != is usually bad idea, but 0.0 is saved without rounding errors.
								{
									result /= b;
								}
								else
								{
									Console.WriteLine("Div by 0");
									op = eOperator.opInvalid;
								}
								break;
							default:
								throw new Exception("This shouldn't happen.");
						}
						if (op != eOperator.opInvalid)
						{
							Console.WriteLine("Result: " + result.ToString());
						}
					}
					else if (input == "quit")
					{
						op = eOperator.opQuit;
					}
					else
					{
						Console.WriteLine("Invalid entry. Type a number or Quit");
					}
						
				}
			}
			else if (input == "quit")
			{
				op = eOperator.opQuit;
			}
			else
			{
				Console.WriteLine("Invalid entry. Type a number or Quit");
			}
		}while(op != eOperator.opQuit);
		Console.WriteLine("Bye");
	}
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.double.tryparse?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
