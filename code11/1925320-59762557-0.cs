`
public void ConfigureServices(IServiceCollection services)
{           
    services.AddMvc().AddNewtonsoftJson(options =>
    {
       options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
}
`
