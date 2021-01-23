    public class MyCustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object result;
            HttpRequestBase request = controllerContext.HttpContext.Request;
            // custom logic sample
            if (request.Params["ParamName"].ToString() == "xyz")
            {
                result = new RegisterModel();
                result.Propertie1 = request.Params["Propertie1"];
            }
            else
            {
                // create another model
            }
    
            return result;
        }
    }
