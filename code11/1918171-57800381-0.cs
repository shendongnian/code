    Try This
    public void ParseCommands(string txtS)
		{
			// String  
			string text = txtS;  
			// String separator  
			string[] delimiterChars = new string[] { ":" };  
			// String Split
			string[] words = text.Split(delimiterChars , StringSplitOptions.None ); 
			
			foreach (string firstName in words)  
        	Console.WriteLine(firstName);
		}
