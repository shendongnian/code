csharp
public class NullStringModelBinder : DefaultModelBinder {
    public override object BindModel(ControllerContext controllerContext,
                                     ModelBindingContext bindingContext) {
        bindingContext.ModelMetadata.ConvertEmptyStringToNull = false;
        return base.BindModel(controllerContext, bindingContext);
    }
}
//register it in Application_Start()
ModelBinders.Binders.Add(typeof(string), new NullStringModelBinder());
