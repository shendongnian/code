	string s = "aa bb cc...";
    // foreach (string w in s.Split())
	string[] array = s.Split();
	foreach (string w in array)
	{
		Console.WriteLine(w);
	}
