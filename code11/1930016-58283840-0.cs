    using System;
    using Project;
    using static Project.Pages;
    
    public class Program
    {
    	public static void Main()
    	{
    		var home = GetPage<Home>();
    		var dashboard = GetPage<Dashboard>();
    		var profile = GetPage<Profile>();
    		
    		Console.WriteLine(home.GetType().Name);
    		Console.WriteLine(dashboard.GetType().Name);
    		Console.WriteLine(profile.GetType().Name);
    	}
    }
    
    namespace Project
    {
    	public static class Pages
    	{
    		public static T GetPage<T>() where T : new()
    		{
    			var page = new T();
    			// ...
    			return page;
    		}
    	}
    	
    	public class Home { /* ... */ }
    	
    	public class Dashboard { /* ... */ }
    	
    	public class Profile { /* ... */ }
    }
