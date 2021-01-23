    public class CustomBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            // TODO: based on some request parameter choose the proper child type
            // to instantiate here
            return new Child();
        }
    }
