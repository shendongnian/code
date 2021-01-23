	string CodeSnippet = Resource1.CodeSnippet;
	StringBuilder CleanCodeSnippet = new StringBuilder();
	bool InsideQuotes = false;
	bool InsideComment = false;
	
	Console.WriteLine("BEFORE");
	Console.WriteLine(CodeSnippet);
	Console.WriteLine("");
	
	for (int i = 0; i < CodeSnippet.Length; i++)
	{
		switch(CodeSnippet[i])
		{
			case '"' : 
				InsideQuotes = !InsideQuotes;
				break;
			case '#' :
				if (!InsideQuotes) InsideComment = true;
				break;
			case '\n' :
				InsideComment = false;
				break;						 
		}
	
		if (!InsideComment)
		{
			CleanCodeSnippet.Append(CodeSnippet[i]);
		}
	}
	
	Console.WriteLine("AFTER");
	Console.WriteLine(CleanCodeSnippet.ToString());
	Console.WriteLine("");
