    public class DynamicJsonBinder : IModelBinder  
    {  
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)  
        { 
            if (!controllerContext.HttpContext.Request.ContentType.StartsWith  
                  ("application/json", StringComparison.OrdinalIgnoreCase))  
            {  
                // not JSON request  
                return null;  
            }  
      
            var inpStream = controllerContext.HttpContext.Request.InputStream;  
            inpStream.Seek(0, SeekOrigin.Begin);  
      
            StreamReader reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);  
            string bodyText = reader.ReadToEnd();  
            reader.Close();  
      
      
            if (String.IsNullOrEmpty(bodyText))  
            {  
                // no JSON data  
                return null;  
            }  
      
            return JsonValue.Parse(bodyText);  
        }  
    } 
    public class DynamicJsonAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new DynamicJsonBinder();
        }
    }
