    public class MyClass
    {
    	// This would work as a method, e.g. GetSettings(), as well.
    	[Lazy]
    	public static Settings Settings
    	{
    		get
    		{
    			using (var fs = File.Open("settings.xml", FileMode.Open))
    			{
    				var serializer = new XmlSerializer(typeof(Settings));
    				return (Settings)serializer.Deserialize(fs);
    			}
    		}
    	}
    
    	[Lazy]
    	public static Settings GetSettingsFile(string fileName)
    	{
    		using (var fs = File.Open(fileName, FileMode.Open))
    		{
    			var serializer = new XmlSerializer(typeof(Settings));
    			return (Settings)serializer.Deserialize(fs);
    		}
    	}
    }
