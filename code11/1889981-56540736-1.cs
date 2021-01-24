		TextInfo myTI = new CultureInfo("ar-DZ",false).TextInfo;
		
		string mainString = "مرحبا";
		char[] arr = mainString.ToCharArray();
		
		Console.WriteLine((int)myTI.ToLower(arr[3]));
		
		Console.WriteLine(char.IsLower(myTI.ToLower(arr[3])));
		
		Console.WriteLine((int)myTI.ToUpper(arr[3]));
		
		Console.WriteLine(char.IsLower(myTI.ToUpper(arr[3])));
		
		string word = "word";
		arr = word.ToCharArray();			
		Console.WriteLine((int)arr[3]);		
		
		Console.WriteLine(char.IsLower(arr[3]));
		
        word = "WORD";
		arr = word.ToCharArray();			       
		Console.WriteLine((int)arr[3]);	
		
		Console.WriteLine(char.IsLower(arr[3]));
