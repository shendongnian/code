public class SeparatedQueryStringAttribute : Attribute, IResourceFilter
{
    private readonly SeparatedQueryStringValueProviderFactory _factory;
    public SeparatedQueryStringAttribute() : this(",") { }
    public SeparatedQueryStringAttribute(string separator) {
        _factory = new SeparatedQueryStringValueProviderFactory(separator);
    }
    public SeparatedQueryStringAttribute(string key, string separator) {
        _factory = new SeparatedQueryStringValueProviderFactory(key, separator);
    }
    public void OnResourceExecuting(ResourceExecutingContext context) {
        context.ValueProviderFactories.Insert(0, _factory);
    }
    public void OnResourceExecuted(ResourceExecutedContext context) { }
}
Actually, according to your `GetByIdsRequest` class, we should detect the existence of the **`[CommaSeparated]` attribute that are decorated on parameter's properties**:
    // CommaSeparatedQueryStringConvention::Apply(action) 
    public void Apply(ActionModel action)
    {
        for (int i = 0; i < action.Parameters.Count; i++)
        {
            var parameter = action.Parameters[i];
            var props = parameter.ParameterType.GetProperties()
                .Where(pi => pi.GetCustomAttributes<CommaSeparatedAttribute>().Count() > 0)
                ;
            if (props.Count() > 0)
            {
                var attribute = new SeparatedQueryStringAttribute(",");
                parameter.Action.Filters.Add(attribute);
                break;
            }
        }
    }
And now it works fine for me.
### A Demo
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/Lm77i.png
