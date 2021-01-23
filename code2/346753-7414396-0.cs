        internal static class SpringApplicationContext
        {
            private static IApplicationContext applicationContext = null;
    
            static SpringApplicationContext()
            {
                applicationContext = ContextRegistry.GetContext();
            }
    
            public static IApplicationContext ApplicationContext
            {
                get { return applicationContext; }
            }
        }
    
    
    
    public class MockURICreate : IURICreate
    {    
    	public string TryCreate(...)
            {		
    		//Mock Configuration
                  return "something";
            }
    }
    
    public class URICreate : IURICreate
    {
    
    	public string TryCreate(...)
         {
                 //Concrete implementation
                  return "something";
         }
    }
    
    internal static class URI
    {
       
       public static string TryCreate(....)
       {
            //Set the URICreate up in your web.config or app.config files for both Unit tests and prod code
            IURICreate create = (IURICreate)SpringApplicationContext.ApplicationContext["URICreate"];
    	return create.TryCreate(...)      
       }
    
    }
    
