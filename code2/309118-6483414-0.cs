    public class CustomViewEngine : WebFormViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations =  new[] {  
                "~/Views/{1}/{0}.aspx",  
                "~/Views/{1}/{0}.ascx",  
                "~/Views/Shared/{0}.aspx",  
                "~/Views/Shared/{0}.ascx",  
                "~/AnotherPath/Views/{0}.ascx"
                // etc
            };
    
            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }
