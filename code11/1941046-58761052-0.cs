csharp
[AttributeUsage(AttributeTargets.Class)]
public class MyRoutePrefixAttribute : Attribute
{
    public MyRoutePrefixAttribute(string prefix) { Prefix = prefix; }
    public string Prefix { get; }
}
And to lookup this `[MyRoutePrefixAttribute]` from the inheritance chain, I create a `RoutePrefixConvention` that will combine the prefixes recursively:
csharp
public class RoutePrefixConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            var prefixes = GetPrefixes(controller.ControllerType);  // [prefix, parentPrefix, grandpaPrefix,...]
            if(prefixes.Count ==  0) continue;
            // combine these prefixes one by one
            var prefixRouteModels = prefixes.Select(p => new AttributeRouteModel(new RouteAttribute(p.Prefix)))
                .Aggregate( (acc , prefix)=> AttributeRouteModel.CombineAttributeRouteModel(prefix, acc));
            selector.AttributeRouteModel =  selector.AttributeRouteModel != null ?
                AttributeRouteModel.CombineAttributeRouteModel(prefixRouteModels, selector.AttributeRouteModel):
                selector.AttributeRouteModel = prefixRouteModels;
        }
    }
    private IList<MyRoutePrefixAttribute> GetPrefixes(Type controlerType)
    {
        var list = new List<MyRoutePrefixAttribute>();
        FindPrefixesRec(controlerType, ref list);
        list = list.Where(r => r!=null).ToList();
        return list;
        // find [MyRoutePrefixAttribute('...')] recursively 
        void FindPrefixesRec(Type type, ref List<MyRoutePrefixAttribute> results)
        {
            var prefix = type.GetCustomAttributes(false).OfType<MyRoutePrefixAttribute>().FirstOrDefault();
            results.Add(prefix);   // null is valid because it will seek prefix from parent recursively
            var parentType = type.BaseType;
            if(parentType == null) return;
            FindPrefixesRec(parentType, ref results);
        }
    }
}
 this convention will *NOT* influence the performance: it only searches all the `[MyRoutePrefixAttribute]` attributes through the inheritance chain **at startup time**. 
Finally, don't forget to add this convention within your startup:
csharp
services.AddControllersWithViews(opts =>{
    opts.Conventions.Add(new RoutePrefixConvention());
});
### Demo
let's create three controllers to test the above RoutePrefixConvention:
`RootApiController` -> `BaseApiController` -> `TestRouteController`
csharp
[ApiController]
[MyRoutePrefix("root/controllers")]
public class RootApiController : ControllerBase { }
[MyRoutePrefix("api/v1")]
public class BaseApiController : RootApiController { }
[Route("testing-route")]
public class TestRouteController : BaseApiController
{
    [HttpGet]
    public string test()
    {
        return "abc";
    }
}
Now when accessing `/root/controllers/api/v1/testing-route`, We'll get a string of  `abc`:
[![custom route prefix through inheritance][1]][1]
  [1]: https://i.stack.imgur.com/pWYyK.gif
