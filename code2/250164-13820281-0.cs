    	public static class Consts
	{
		static bool _bIsInDebugMode = false;
		static Consts()
		{
			var oConfigSection = System.Configuration.ConfigurationManager.GetSection("system.web/compilation") as System.Web.Configuration.CompilationSection;
			_bIsInDebugMode  = oConfigSection != null && oConfigSection.Debug;
		}
		
		public static bool DEBUG { get { return _bIsInDebugMode; } }
	}
