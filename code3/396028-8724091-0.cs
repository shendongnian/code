    public class CountryRowComparer : IEqualityComparer<DataRow>
    {
    	public bool Equals(DataRow r1, DataRow r2)
    	{
    		return r1["Country"] == r2["Country"];
    	}
    
    	public int GetHashCode(DataRow r)
    	{		
    		return r["Country"].GetHashCode();
    	}
    }
