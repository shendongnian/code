    public class EmptyStringModelBinder : DefaultModelBinder 
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            bindingContext.ModelMetadata.ConvertEmptyStringToNull = false;
            Binders = new ModelBinderDictionary() { DefaultBinder = this };
            return base.BindModel(controllerContext, bindingContext);
        }
    }
