    class Program
    {
    	static void Main(string[] args)
    	{
    		Print(Parse("HelloWorld"));
    		Print(Parse("HelloWORld"));
    		Print(Parse("helloworld"));
    		Print(Parse("HellOWORLd"));
    		Console.ReadLine();
    	}
    
    	static void Print(IEnumerable<string> input)
    	{
    		foreach (var s in input)
    		{
    			Console.Write(s);
    			Console.Write(' ');
    		}
    		Console.WriteLine();
    	}
    
    	static IEnumerable<string> Parse(string input)
    	{
    		var sb = new StringBuilder();
    		for (int i = 0; i < input.Length; i++)
    		{
    			if (!char.IsUpper(input[i]))
    			{
    				sb.Append(input[i]);
    				continue;
    			}
    			if (sb.Length > 0)
    			{
    				yield return sb.ToString();
    				sb.Clear();
    			}
    			sb.Append(input[i]);
    			if (char.IsUpper(input[i + 1]))
    			{
    				sb.Append(input[++i]);
    				yield return sb.ToString();
    				sb.Clear();
    			}
    		}
    		if (sb.Length > 0)
    		{
    			yield return sb.ToString();
    		}
    	}
    }
