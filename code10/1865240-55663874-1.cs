c#
// using Abp.ObjectMapping;
var fooController = new FooController(mockFooService.Object);
fooController.ObjectMapper = LocalIocManager.Resolve<IObjectMapper>(); // Add this line
# 2. `NullObjectMapper` in injected instances
Add `[DependsOn(typeof(AbpAutoMapperModule))]` to your test module.
c#
[DependsOn(typeof(AbpAutoMapperModule))]
public class MyTestModule : AbpModule
{
    // ...
}
