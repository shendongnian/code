csharp
public class MyFeatureProvider: ControllerFeatureProvider
    {
        private readonly bool condition;
        public MyFeatureProvider(bool condition)
        {
            this.condition = condition;
        }
        protected override bool IsController(TypeInfo typeInfo) {
            if (condition && typeInfo.Name == "ExampleController") {
                return false;
            }
            return base.IsController(typeInfo);
        }
    }
public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc().ConfigureApplicationPartManager(mgr => {
                mgr.FeatureProviders.Add(new MyFeatureProvider(true));
            });            
        }
}
I'll link [the source code][1] in case you'd like to check out stock standard implementation and see how it works for reference
  [1]: https://github.com/aspnet/AspNetCore/blob/5ff9ed68d1cf6c89d72d27a69b00ed0ecd34daed/src/Mvc/Mvc.Core/src/Controllers/ControllerFeatureProvider.cs
