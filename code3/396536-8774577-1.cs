    void Main()
    {
    	
    	Console.WriteLine ("303-867-5309".DetermineScope() == InputScope.Phone); // True
    	Console.WriteLine ("1811 South Quebec Way".DetermineScope() == InputScope.Address); // True
    	Console.WriteLine ("Turk 181".DetermineScope() == InputScope.Text); // True
    
    }
    
    public enum InputScope
    	{
    	   Phone,           // Digits and dividers
    	   Address,         // number space then text
             Text,            // Everything is text...final catch all.
    	};
    	
    
    public static class TestCaseExtensions
    {
    		
    	public static InputScope DetermineScope(this string text)
    	{
    	
    		string pattern = @"
    (?(^[\d.\-/\\]+$)           # If: First check for phone; just numbers and dividers (no spaces)
       (?<Phone>[\d.\-/\\]+)    #    Place into Phone named capture group
     |                          # Else: start a new check
       (?(^\d+\s\w+)            # If Check for address (if Address)
    	 (?<Address>.*)       #    Looks like its an address, place into address capture group
    	|                     # Else
    	 (?<Text>.*)          #   Nope just text, place into text capture group
       )
    )";
    
    	var result = InputScope.Text; // Default to the lowest...text
    	
    	// Ignore allows us to document pattern; it is not related to processing text.
    	var match = Regex.Match(text, pattern, RegexOptions.IgnorePatternWhitespace);
    	
    	if (match.Success)
    	{
    		result = 
    		Enum.GetValues(typeof(InputScope))
    		    .OfType<InputScope>()
    			.Where (tp => match.Groups[tp.ToString()].Success)
    			.First ();
    	
    	}
    	
    	return result;
    	
    	}
    
    }
