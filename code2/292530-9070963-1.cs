    namespace MyApp.CustomModelBinders
    {
        public class EnumModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                ModelState modelState = new ModelState { Value = valueResult };
                object actualValue = null;
    
                try
                {
                    return Enum.ToObject(Type.GetType(bindingContext.ModelType.AssemblyQualifiedName), Convert.ToInt32(valueResult.AttemptedValue));
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }
    
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                return actualValue;
            }
        }
    }
