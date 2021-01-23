    public class MyModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            // TODO: decide if you need to instantiate or not the model
            // based on the context
            if (!ShouldInstantiateModel)
            {
                return null;
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
