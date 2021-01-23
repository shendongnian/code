	public class App : Application
	{
		[STAThreadAttribute()]
		public static void Main()
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
			// etc...
		}
	
		// etc...
