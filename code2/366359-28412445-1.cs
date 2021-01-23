    public class Program
    {
    	public static void Main()
    	{
             //original date
    		string _date = "Thu Jan 15 11:32:09 +0200 2015";
             // Describes the date format
    		string _parsePattern = "ddd MMM dd HH:mm:ss zzz yyyy"; 
    		
    		 DateTimeOffset dto = DateTimeOffset.ParseExact(_date, _parsePattern, CultureInfo.InvariantCulture);
            
    		 //last settings
    		Console.WriteLine(dto.ToString("dd.MM.yyyy hh:mm:ss",CultureInfo.CreateSpecificCulture("tr-TR")));
    	}
    }
