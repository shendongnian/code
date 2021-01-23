    namespace HelloWorld
    {
    	#region NameSpaces
    
    	using System;
    	using Cinchoo.Core.Configuration;
    
    	#endregion NameSpaces
    
    	[ChoConfigurationSection("sample")]
    	public class SampleConfigSection : ChoConfigurableObject
    	{
    		#region Instance Data Members (Public)
    
    		[ChoPropertyInfo("name", DefaultValue="Mark")]
    		public string Name;
    
    		[ChoPropertyInfo("message", DefaultValue="Hello World!")]
    		public string Message;
    
    		#endregion
    	}
    
    	static void Main(string[] args)
    	{
    		SampleConfigSection sampleConfigSection = new SampleConfigSection();
    		Console.WriteLine(sampleConfigSection.ToString());
    	}
    
    }
