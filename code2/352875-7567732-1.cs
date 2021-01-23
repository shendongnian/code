    void Main()
    {
    	List<string> stringList = new List<string> { "00012345.pdf","12345.pdf","notaduplicate.jpg","3453456363234.jpg"};
    	
    	IEqualityComparer<string> comparer = new SubstringComparer();
    	
    	var duplicates = stringList.GroupBy (s => s, comparer).Where(grp => grp.Count() > 1);
    	
    	// do something with grouped duplicates...
    
    }
    
    // Not safe for null's !
    // NB do you own parameter / null checks / string-case options etc !
    public class SubstringComparer : IEqualityComparer<string> {
       
       public bool Equals(string left, string right) {
       		return left.Contains(right) || right.Contains(left);
       }
       
       public int GetHashCode(string value) {
       	return base.GetHashCode();
       }
       
    }
