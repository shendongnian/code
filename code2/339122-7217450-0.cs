    public class MyViewEngine : RazorViewEngine
    {
        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            //Some Logic to check for file
        }
    }
    
    ViewEngines.Engines.Clear();
    ViewEngines.Engines.Add(new CustomViewEngine());
  
