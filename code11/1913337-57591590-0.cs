    public class LocationModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
          ModelBindingContext bindingContext)
        {
            string key = bindingContext.ModelName;
            ValueProviderResult val = bindingContext.ValueProvider.GetValue(key);
            if (val != null)
            {
                string s = val.AttemptedValue as string;
                if (s != null)
                {
                    return Location.TryParse(s);
                }
            }
            return null;
        }
    }
