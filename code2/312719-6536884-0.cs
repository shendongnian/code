    public class MyModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var id = bindingContext.ValueProvider.GetValue("id");
            if (id != null)
            {
                return GetModelFromDataStoreById(id.AttemptedValue);
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
