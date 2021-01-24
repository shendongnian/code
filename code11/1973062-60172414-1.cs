c#
void Main()
{
	string temp;
	Console.WriteLine("question");
	while (true)
	{
		temp = Console.ReadLine();
		if (temp == "a")
			Console.WriteLine("Incorrect");	
		else if (temp == "b")
			Console.WriteLine("Incorrect");
		else if (temp == "c")
			Console.WriteLine("Correct");
		else if (temp == "exit") // providing a way to exit the loop
			break;
		else { } // ignore input			
	}
}
