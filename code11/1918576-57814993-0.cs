    public class ObjectAComparer : IComparer<ObjectA>
    {
    	public int Compare(ObjectA x, ObjectA y)
    	{
            // Quite possibly not the ordering logic you want. Change as needed.
            // "IsNumber" means what you seem to have defined as numbers.
    		bool xIsNumber = x.A.Any(c => char.IsNumber(c));
    		bool yIsNumber = y.A.Any(c => char.IsNumber(c));
    		
    		bool sameKind = !(xIsNumber ^ yIsNumber);
    		if (sameKind) return x.A.CompareTo(y.A); // Both numbers or both not numbers
    		
    		if (xIsNumber) return 1;
    		
    		return -1;
    	}
    }
