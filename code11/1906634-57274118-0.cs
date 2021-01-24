    public static void Main(string[] args)
	{
		double answer;
		bool Continue = true;
		Console.WriteLine("\tCalculator");
		Console.WriteLine("--------------------------\n");
		Console.WriteLine("   Math Operations: ");
		Console.WriteLine(" --------------------");
		Console.WriteLine("  Multiplication: *");
		Console.WriteLine("        Addition: +");
		Console.WriteLine("     Subtraction: -");
		Console.WriteLine("        Division: /");
		while (Continue)
		{
			Console.WriteLine("\nEnter your equation below:");
			Console.WriteLine("    For example: 5 + 5 ");
			
			string[] values = Console.ReadLine().Split(' ');
			try{
				double firstNum = double.Parse(values[0]); 
				string operation = (values[1]);
				double secondNum = double.Parse(values[2]);
				switch(operation){
					case "*":
						answer = firstNum * secondNum;
						Console.WriteLine("\n" + firstNum + " * " + secondNum + " = " + answer);
						break;
					case "/":
						answer = firstNum / secondNum;
						Console.WriteLine("\n" + firstNum + " / " + secondNum + " = " + answer);
						break;
					case "+":
						answer = firstNum + secondNum;
						Console.WriteLine("\n" + firstNum + " + " + secondNum + " = " + answer);
						break;
					case "-":
						answer = firstNum - secondNum;
						Console.WriteLine("\n" + firstNum + " - " + secondNum + " = " + answer);
						break;
					default:
						Console.WriteLine("Sorry that is not correct format! Please restart!");
						break;
				}
				Console.WriteLine("\n\nDo you want to continue?");
				Console.WriteLine("Type in Yes to continue or press any other key and then press enter to quit:");
				string response = Console.ReadLine();
				Continue = (response == "Yes");
			}
			catch(FormatException ex){
				Console.WriteLine("You entered a bad operation, try another one");
			}
		}
	}
