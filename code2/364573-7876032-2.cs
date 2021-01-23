    public abstract class MySpecialListBase
	{
	    public int Count()
		{
		    return this.GetCount();
		}
		
		protected abstract int GetCount();
	}
    public sealed class MySpecialArrayList : MySpecialListBase
	{
	    int count;
	
	    public new int Count()
		{
		    return this.count;
		}
		
		protected override int GetCount()
		{
			return this.count;
		}
	}
	
