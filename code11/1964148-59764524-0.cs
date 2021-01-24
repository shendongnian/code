    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Serialization;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
    }
