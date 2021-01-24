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
        // repeat until the user wants to quit.
		do // while(op != eOperator.opQuit)
		{
			Console.Write("a = ");
			input = Console.ReadLine().ToLower().Trim();
			if (double.TryParse(input, out a))
			{
                // input is a valid double and was stored in a
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
                    // user didn't choose to quit or type something invalid
					Console.Write("b = ");
					input = Console.ReadLine().ToLower().Trim();
					if (double.TryParse(input, out b))
					{
                        // input is a valid double and was parsed into b
						double result = a; // we use the operator on a, so we might as well just store a into the result right away.
                        // do the operation on result.
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
                                // this if branch checked for the other two operators. since we never chanced op after that check, this exception should never happen.
                                // it is still a good idea to include it to find errors in your logic, should they have occurred.
								throw new Exception("This shouldn't happen.");
						}
						if (op != eOperator.opInvalid)
						{
							Console.WriteLine("Result: " + result.ToString());
						}
                        // the only invalid operation is div by 0 for now. the message was sent to the user in that case, so no else is needed at this point.
                        // alternatively you can store an error message into a string, and when op = opInvalid, then display that error message here centralized.
                        // this would be a good idea if multiple things can go wrong.
					}
					else if (input == "quit")
					{
                        // input for b was an invalid number, but input was 'quit'
						op = eOperator.opQuit;
					}
					else
					{
                        // input for b was an invalid number and also not 'quit', display error message
						Console.WriteLine("Invalid entry. Type a number or Quit");
					}
				}
			}
			else if (input == "quit")
			{
                // input for a was invalid number, but 'quit'
				op = eOperator.opQuit;
			}
			else
			{
                // input for a was invalid number and also not 'quit'
				Console.WriteLine("Invalid entry. Type a number or Quit");
			}
        // repeat until the user wants to quit.
		}while(op != eOperator.opQuit);
		Console.WriteLine("Bye");
	}
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.double.tryparse?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
