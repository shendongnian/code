public class Startup
{
    public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        Configuration = configuration;
        Logger = loggerFactory.CreateLogger<Startup>();
    }
    public IConfiguration Configuration { get; }
    private ILogger<Startup> Logger { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        //Bind configuration settings
        services.Configure<PolygonConfiguration>(Configuration.GetSection(nameof(PolygonConfiguration)));
        //Add validator
        services.AddSingleton<IValidateOptions<PolygonConfiguration>, PolygonConfigurationValidator>();
        //Validate configuration and add to DI container
        services.AddSingleton<PolygonConfiguration>(container =>
        {
            try
            {
                return container.GetService<IOptions<PolygonConfiguration>>().Value;
            }
            catch (OptionsValidationException ex)
            {
                foreach (var validationFailure in ex.Failures)
                    Logger.LogError($"appSettings section '{nameof(PolygonConfiguration)}' failed validation. Reason: {validationFailure}");
                throw;
            }
        });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
       ...
    }
}
appSettings.json with some valid and invalid values
json
{
  "PolygonConfiguration": {
    "SupportedPolygons": [
      {
        "Description": "Triangle",
        "NumberOfSides": 3
      },
      {
        "Description": "Invalid",
        "NumberOfSides": -1
      },
      {
        "Description": "",
        "NumberOfSides": 6
      }
    ]
  }
}
The validator class itself
    public class PolygonConfigurationValidator : IValidateOptions<PolygonConfiguration>
    {
        public ValidateOptionsResult Validate(string name, PolygonConfiguration options)
        {
            if (options is null)
                return ValidateOptionsResult.Fail("Configuration object is null.");
            if (options.SupportedPolygons is null || options.SupportedPolygons.Count == 0)
                return ValidateOptionsResult.Fail($"{nameof(PolygonConfiguration.SupportedPolygons)} collection must contain at least one element.");
            foreach (var polygon in options.SupportedPolygons)
            {
                if (string.IsNullOrWhiteSpace(polygon.Description))
                    return ValidateOptionsResult.Fail($"Property '{nameof(Polygon.Description)}' cannot be blank.");
                if (polygon.NumberOfSides < 3)
                    return ValidateOptionsResult.Fail($"Property '{nameof(Polygon.NumberOfSides)}' must be at least 3.");
            }
            return ValidateOptionsResult.Success;
        }
    }
And the configuration models
    public class Polygon
    {
        public string Description { get; set; }
        public int NumberOfSides { get; set; }
    }
    public class PolygonConfiguration
    {
        public List<Polygon> SupportedPolygons { get; set; }
    }
  [1]: https://github.com/aspnet/Options/pull/266/commits/95495473d26eb30bbd079f20a04b15c9464c49d9
