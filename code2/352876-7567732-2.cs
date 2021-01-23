    void Main()
    {
    	List<string> stringList = new List<string> { "00012345.pdf","12345.pdf","notaduplicate.jpg","3453456363234.jpg"};
    	
    	IEqualityComparer<string> comparer = new NumericFilenameEqualityComparer ();
    	
    	var duplicates = stringList.GroupBy (s => s, comparer).Where(grp => grp.Count() > 1);
    	
    	// do something with grouped duplicates...
    
    }
        
    // Not safe for null's !
    // NB do you own parameter / null checks / string-case options etc !
    public class NumericFilenameEqualityComparer : IEqualityComparer<string> {
    
       private static Regex digitFilenameRegex = new Regex(@"\d+", RegexOptions.Compiled);
    
       public bool Equals(string left, string right) {
       	
    		Match leftDigitsMatch = digitFilenameRegex.Match(left);
    		Match rightDigitsMatch = digitFilenameRegex.Match(right);
    				
    		long leftValue = leftDigitsMatch.Success ? long.Parse(leftDigitsMatch.Value) : long.MaxValue;
    		long rightValue = rightDigitsMatch.Success ? long.Parse(rightDigitsMatch.Value) : long.MaxValue;
    		
    		return leftValue == rightValue;
       }
    
       public int GetHashCode(string value) {
       		return base.GetHashCode();
       }
    
    }
