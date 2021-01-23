    	string test = "strings like [5] [12]";
	Regex getBrackettedText = new System.Text.RegularExpressions.Regex(@"\[\d+\] \[\d+\]");
	string[] values = getBrackettedText.Match(test).Value.Split();
	
	Regex getNumber = new System.Text.RegularExpressions.Regex(@"\d+");
		
	foreach(string value in values)
	{
		Console.WriteLine(int.Parse(getNumber.Match(value).Value));
	}
