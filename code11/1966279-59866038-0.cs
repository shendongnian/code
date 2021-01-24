    internal static class LoadResourceDictionary
    {
    	static LoadResourceDictionary()
    	{
    		resourceDictionary = Application.LoadComponent(new Uri("/DllName;component/Shared/ReusedDictionary.xaml",UriKind.RelativeOrAbsolute)) as ResourceDictionary;
    	}
    
    	public static ResourceDictionary resourceDictionary;
    }
