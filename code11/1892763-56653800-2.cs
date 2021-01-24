c#
public static void Main()
	{
            Dictionary<char, string> dDict = new Dictionary<char, string>() { { 'a', "Alfa" }, { 'b', "Bravo" } };
            string result = string.Join(" ", "abc".Select(x => dDict.Select(p=>p.Key).Contains(x) ? dDict[char.ToLower(x)] : x.ToString()));
            Console.WriteLine(result);
	}
output:
Alfa Bravo
