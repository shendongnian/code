	public class WebDataContextProvider : DataContextProvider 
	{
		[ThreadStatic]
		private static DataContext Current;
		
	    public override DataContext GetCurrent()
		{
		    return Current;
		}
		
		public override void OpenNew()
		{
			Current = new DataContext();
		}
	}
