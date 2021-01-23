    public class BooleanModelBinder : IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            // do checks here to parse boolean
            return (bool)value.AttemptedValue;
        }
    }
