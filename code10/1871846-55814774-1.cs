public class MyModelBinder : IModelBinder
{
    private readonly IModelMetadataProvider _modelMetadataProvider;
    private readonly IModelBinderFactory _modelBinderFactory;
    public MyModelBinder(IModelMetadataProvider modelMetadataProvider, IModelBinderFactory modelBinderFactory)
    {
        _modelMetadataProvider = modelMetadataProvider;
        _modelBinderFactory = modelBinderFactory;
    }
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        var typeValue = bindingContext.ValueProvider.GetValue(nameof(ComplexModel.Type)).Values;
        var nameValue = bindingContext.ValueProvider.GetValue(nameof(ComplexModel.Name)).Values;
        var finalModel = new ComplexModel
        {
            Name = nameValue,
            Type = typeValue
        };
        var innerType = LookupType(typeValue);
        if (innerType != null)
        {
            finalModel.Parameters = Activator.CreateInstance(innerType);
            var modelMetadata = _modelMetadataProvider.GetMetadataForType(innerType);
            var modelBinder = _modelBinderFactory.CreateBinder(new ModelBinderFactoryContext
            {
                Metadata = modelMetadata,
                CacheToken = modelMetadata
            });
            var modelName = bindingContext.BinderModelName == null ? "Parameters" : $"{bindingContext.BinderModelName}.Parameters";
            using (var scope = bindingContext.EnterNestedScope(modelMetadata, modelName, modelName, finalModel.Parameters))
            {
                await modelBinder.BindModelAsync(bindingContext);
            }
        }
        bindingContext.Result = ModelBindingResult.Success(finalModel);
        return;
    }
    //NOTE: this maps a type string to a Type.  
    //DO NOT transmit a type FullName and use reflection to activate, this could cause a RCE vulnerability.
    private Type LookupType(string type)
    {
        switch (type)
        {
            case "text":
                return typeof(TextParam);
            case "int":
                return typeof(IntParam);
        }
        return null;
    }
}
//Sample of ComplexModel classes
[ModelBinder(typeof(MyModelBinder))]
public class ComplexModel
{
    public string Name { get; set; }
    public string Type { get; set; }
    public object Parameters { get; set; }
}
public class TextParam
{
    public string Text { get; set; }
}
public class IntParam
{
    public int Number { get; set; }
}
> NOTE: When doing custom deserialization with a Type, it is important to limit the list of allowed types to be deserialized. If you would accept a type's FullName and use reflection to activate, this could cause a RCE vulnerability since there are some [types][1] in .NET that execute code when a property is set. 
  [1]: https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Deserialization_Cheat_Sheet.md#known-net-rce-gadgets
