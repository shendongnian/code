        var testText = @"[CIty]";
		Console.WriteLine("Original text: " + testText);
		
		
		var pattern = @"\[City\]";
		
		if(!Regex.IsMatch(testText, pattern))
		{
			if(Regex.IsMatch(testText, pattern, RegexOptions.IgnoreCase))
			{
				//use the below updated value as you wish
				var updatedStringVal = Regex.Replace(testText, pattern, "[City]", RegexOptions.IgnoreCase);
				Console.WriteLine("Updated text: " + updatedStringVal);
			}
		}
  [1]: https://dotnetfiddle.net/x0qjJU
