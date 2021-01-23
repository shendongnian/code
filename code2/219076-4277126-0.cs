    public class ModelBinder : DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var actionName = controllerContext.RouteData.Values["action"] != null
                                     ? controllerContext.RouteData.Values["action"].ToString()
                                     : string.Empty;
    
            var attribute = controllerContext.Controller.GetType().GetMethods()
                .Where(x => x.Name == actionName)
                .Where(x => x.GetCustomAttributes(false).Any(a => a.GetType() == typeof(CustomActionFilterAttribute)))
                .Select(x => x.GetCustomAttributes(typeof(CustomActionFilterAttribute), false).FirstOrDefault())
                .FirstOrDefault() as CustomActionFilterAttribute;
    
            if(attribute != null && attribute.AnyProperty)
            {
                // Do what you want
            }
        }
    }
