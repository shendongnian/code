c#
public static void Main()
	{
		Dictionary<char, string> dDict = new Dictionary<char, string>()	{{'a', "Alfa"}, 
        {'b', "Bravo"}};
		string result = string.Join(" ", "a".Select(x => dDict[char.ToLower(x)]));
		Console.WriteLine(result);
	}
output:
Alfa
