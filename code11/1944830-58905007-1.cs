    void Main()
    {
	    var input = "1 A & B 2 C & D";	
    	var result = Parse(input);
        Console.WriteLine(String.Join("\n", result));
    }
    static IEnumerable<string> Parse(string input)
    {
	    var words = input.Split();	
	    var builder = new StringBuilder();
	
    	foreach (var word in words)
	    {
	        if (int.TryParse(word, out var value))
	        {
	            if (builder.Length > 0)
	            {
	                yield return builder.ToString();
	                builder.Clear();
	            }
	            yield return word;
    	    }
	        else 
	        {
	            if (builder.Length > 0)
	            {           
	                builder.Append(' ');
	            }
	            builder.Append(word);
	        }
	    }
	
    	if (builder.Length > 0) // leftovers
    	{
    	    yield return builder.ToString();
	    }
    }
