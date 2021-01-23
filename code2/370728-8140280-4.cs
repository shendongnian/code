    public class ChangeableModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.Controller.ViewData.Keys.ToList().IndexOf(bindingContext.ModelName) < 0)
                controllerContext.Controller.ViewData.Add(bindingContext.ModelName, bindingContext.ModelMetadata);
            return base.BindModel(controllerContext, bindingContext);
        }
    }
