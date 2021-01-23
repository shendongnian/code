    public class TimeSpanModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            string attemptedValue = value.AttemptedValue;
            // Custom parsing and return the TimeSpan? here.
        }
    }
