	public class PreApplicationStart
	{
		public static void InitializeApplication()
		{
			System.Web.WebPages.Razor.WebCodeRazorHost.AddGlobalImport("insert.your.namespace.here");
		}
	}
