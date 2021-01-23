    public static class PriceParser {
	  private const string MATCH_STRING = @"Current Hourly Price \(HOEP\): \$\d+\.\d\d/MWh \((\d+\.\d\d)¢/kWh\)";
	  private const string REPLACE_STRING = @"Current Hourly Price $1 ¢/kWh";
	  private static readonly Regex regex=new Regex(MATCH_STRING,RegexOptions.Compiled);
	  private static readonly Regex entirePageRegex=new Regex(string.Format("^.*{0}.*$",MATCH_STRING),RegexOptions.Compiled|RegexOptions.Singleline);
	  
	  public static void get_HEOP1(string web) {
	  	Console.WriteLine(regex.Replace(web,REPLACE_STRING));
	  }
	  
	  public static void get_HEOP2(string web) {
	  	Console.WriteLine(entirePageRegex.Replace(web,REPLACE_STRING));
	  }
    }
