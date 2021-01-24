    List<string> x = new List<string>();
	x.Add("DFG0001D");
	x.Add("AWK0007E");
	x.Add("ORK0127E");
	x.Add("AWK0007D");
	x.Add("DFG0001E");
	x.Add("ORK0127D");
	x.Sort(delegate(string c1, string c2) { 
	string a = c1.Substring(0, 3)+c1.Substring(c1.Length-1, 1);
	string b = c2.Substring(0, 3)+c2.Substring(c2.Length-1, 1);
	return (a.CompareTo(b)); 
	});
	Console.WriteLine("After sort...");
	foreach (string i in x)
	{
		Console.WriteLine(i);
	}
