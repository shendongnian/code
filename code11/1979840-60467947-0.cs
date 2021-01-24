c#
public delegate string UserInput();
internal class Class1
{
	//Our delegate
	public delegate string EnterName();
	static void Main(string[] args)
	{
		UserInput name = Getname;
		UserInput age = GetAge;
		PlayWithDelegate(name, age);
	}
	private static string GetAge()
	{
		Console.WriteLine("Please enter your age : ");
		string result = Console.ReadLine();
		if (result == "") result = " a mystery";
		return result;
	}
	private static void PlayWithDelegate(UserInput name, UserInput age)
	{
		Console.WriteLine("your name is {0} and age is {1}", name(), age());
		Console.ReadLine();
	}
	public static string Getname()
	{
		Console.WriteLine("Please enter your name : ");
		string result = Console.ReadLine();
		if (result == "") result = " a mystery";
		return result;
	}
}
