    string textToEncode = "abc\rdefabdg";
	
	textToEncode = textToEncode.ToLower();
	
	char[] distinctLetters = textToEncode.Distinct().ToArray();
	var count = distinctLetters.Length;
	
	Console.WriteLine("Letters used in text (old):");
    for (int i = 0; i < count; i++)
    {
        var letter = distinctLetters[i];
        if (Equals(letter, " "))
        {
             Console.Write("<space>");
        }
        else
        {
             Console.Write(distinctLetters[i]);
        }
    }
    Console.WriteLine();
    Console.WriteLine("Letters used in text (new):");
    for (int i = 0; i < count; i++)
    {
       var letter = distinctLetters[i];
           
       if (!char.IsLetter(letter))
           continue;
       Console.Write(distinctLetters[i]);
    }
