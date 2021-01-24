    public static class Ex
    {
    	private static string Peek(this string source, int peek) => (source == null || peek < 0) ? null : source.Substring(0, source.Length < peek ? source.Length : peek);
    	private static (string, string) Pop(this string source, int pop) => (source == null || pop < 0) ? (null, source) : (source.Substring(0, source.Length < pop ? source.Length : pop), source.Length < pop ? String.Empty : source.Substring(pop));
    
    	public static string[] ParseCsvLine(this string line)
    	{
    		return ParseCsvLineImpl(line).ToArray();
    		IEnumerable<string> ParseCsvLineImpl(string l)
    		{
    			string remainder = line;
    			string field;
    			while (remainder.Peek(1) != "")
    			{
    				(field, remainder) = ParseField(remainder);
    				yield return field;
    			}
    		}
    	}
    
    	private const string DQ = "\"";
    
    	private static (string field, string remainder) ParseField(string line)
    	{
    		if (line.Peek(1) == DQ)
    		{
    			var (_, split) = line.Pop(1);
    			return ParseFieldQuoted(split);
    		}
    		else
    		{
    			var field = "";
    			var (head, tail) = line.Pop(1);
    			while (head != "," && head != "")
    			{
    				field += head;
    				(head, tail) = tail.Pop(1);
    			}
    			return (field, tail);
    		}
    	}
    
    	private static (string field, string remainder) ParseFieldQuoted(string line)
    	{
    		var field = "";
    		var head = "";
    		var tail = line;
    		while (tail.Peek(1) != "" && (tail.Peek(1) != DQ || tail.Peek(2) == DQ + DQ))
    		{
    			if (tail.Peek(2) == DQ + DQ)
    			{
    				(head, tail) = tail.Pop(2);
    				field += DQ;
    			}
    			else
    			{
    				(head, tail) = tail.Pop(1);
    				field += head;
    			}
    		}
    		if (tail.Peek(2) == DQ + ",")
    		{
    			(head, tail) = tail.Pop(2);
    		}
    		else if (tail.Peek(1) == DQ)
    		{
    			(head, tail) = tail.Pop(1);
    		}
    		return (field, tail);
    	}
    }
