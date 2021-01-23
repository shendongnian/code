	public class WebDataContextProvider : DataContextProvider 
	{
		private const string Key = "WebDataContextProvider.DataContext";
		
	    public override DataContext GetCurrent()
		{
		    return (DataContext)HttpContext.Current.Items[Key];
		}
		
		public override void OpenNew()
		{
			HttpContext.Current.Items[Key] = new DataContext();
		}
	}
	
