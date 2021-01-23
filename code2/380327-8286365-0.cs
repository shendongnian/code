    public class Class1 : IEnumerable<int>
    {
    	public IEnumerator<int> GetEnumerator()
    	{
    		yield return 1;
    		yield return 2;
    		yield return 3;
    		yield return 4;
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    }
