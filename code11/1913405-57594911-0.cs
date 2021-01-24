	string s = "12345 Manchester Avenue Apt 123";
	if(s.Length > 25) 
	{
        // find the last space within the first 25 characters
		int lastSpace = s.LastIndexOf(' ',24);
		
		string s1 = s.Substring(0,lastSpace);
		string s2 = s.Substring(lastSpace+1);
		
		Console.WriteLine(s1);
		Console.WriteLine(s2);
	}
    //output:
    12345 Manchester Avenue
    Apt 123
    
