	static void Main()     
	{    
		Console.WriteLine(
		Regex.Replace("SMITH 9-2 #3-10H13",	@"(\w+\s+)(\d+)-(\d+)", 
		m=> m.Groups[1].Value + 
			m.Groups[2].Value.PadLeft(2,'0') + "-" +
			m.Groups[3].Value.PadLeft(2,'0')
			));
	}      
