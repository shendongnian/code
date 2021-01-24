cs
public override void BindModel(ModelBindingContext bindingContext)
{
    var providers = bindingContext.ValueProvider as System.Collections.IList;
    var formProvider = providers?.OfType<JQueryFormValueProvider>().FirstOrDefault();
    if (formProvider != null)
    {
        var (_, value) = formProvider.GetKeysFromPrefix(string.Empty).First();
        bindingContext.BinderModelName = value;
        bindingContext.FieldName = value;
        bindingContext.ModelName = value;
    }
    base.BindModel(bindingContext);
}
