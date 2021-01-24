    public class Program
    {
    	public static void Main(string[] args)
    	{
    		string text = "<wd:response><wd:response-data></wd:response-data></wd:response >";
    		string replacePattern = "response";
    		string pattern = "(wd:response)";
    		string replacedPattern = Regex.Replace(text, pattern, replacePattern);
    		Console.WriteLine(replacedPattern);
    	}
    }
