    public class Program
    {
    	public static void Main(string[] args)
    	{
    		string text = "<wd:response><wd:response-data></wd:response-data></wd:response >";
    		string replacePattern = "response";
    		string pattern = @"<[/]?(wd:response)\s?>";
    		string replacedPattern = Regex.Replace(text, pattern, match =>
    		{
    		    // Extract the first group
    			Group group = match.Groups[1];
    			
    			// Replace the group value with the replacePattern
    			return string.Format("{0}{1}{2}", match.Value.Substring(0, group.Index - match.Index), replacePattern, match.Value.Substring(group.Index - match.Index + group.Length));
    		});
    		Console.WriteLine(replacedPattern);
    	}
    }
