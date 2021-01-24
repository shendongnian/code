    string input = "Even if I'm a string, I still like odd numbers like 1, 3, 5 ..etc.";
    
    var text = input.ToCharArray();
    
    List<char> letters = new List<char>();
    
    for(int x =0; x < text.Length; x++)
    {
    	if (char.IsLetter(text[x]) && char.IsLower(text[x]) && !letters.Contains(text[x]))
    	{
    		letters.Add(text[x]);
    		Console.WriteLine($"{text[x]}");
    	}
    		
    }
 
