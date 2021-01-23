    public static IEnumerable<string> SplitOnLength(this string input, int length)
    {
    	var words = input.Split(new [] { " ", }, StringSplitOptions.None);
    	var result = words.First();
    	foreach (var word in words.Skip(1))
    	{
    		if (result.Length + word.Length > length)
    		{
    			yield return result;
    			result = word;
    		}
    		else
    		{
    			result += " " + word;
    		}
    	}
    	yield return result;
    }
