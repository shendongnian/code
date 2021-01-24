try
{
    userInput = double.Parse(Console.ReadLine());
	if (userInput == 999)
	{
		break;
	}
	else if (userInput < 0)
	{
		Console.WriteLine("Invalid input");
	} 
	else
	{
		scores[count++] = userInput;
	}
}
catch(Exception e)  // will take care of letters
{
	Console.WriteLine("You enter an Invalid input !"):
}
