c#
void Main()
{
	string temp;
	Console.WriteLine("question");
	while (true)
	{
		temp = Console.ReadLine();
		if (temp == "a")
		{
			Console.WriteLine("Incorrect");
		}
		if (temp == "b")
		{
			Console.WriteLine("Incorrect");
		}
		if (temp == "c")
		{
			Console.WriteLine("Correct");
		}
		if (temp == "exit") // providing a way to exit the loop
		{
			break;
		}
		else
		{
			// do nothing here to ignore input
			//Console.WriteLine("Not a valid response");
		}
	}
}
