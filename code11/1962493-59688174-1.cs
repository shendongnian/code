    public static void Register()
    {
        var thisAssembly = typeof(SwaggerConfig).Assembly;
        GlobalConfiguration.Configuration
            .EnableSwagger("docs/{apiVersion}", c =>
            {
                c.SingleApiVersion("v1", "Title Of API");
                c.Schemes(new List<string> { "http", "https" });
                c.UseFullTypeNameInSchemaIds();
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml"));
            });
    }
Last line in the code above enabled the XML comment tagging.
One other thing you have to do is, 
1. Go to Properties of Project (not Solution)
2. Build / Output -> Add path to XML Documentation File.
For Reference Purposes, [this](http://wmpratt.com/swagger-and-asp-net-web-api-part-1/) was quite helpful.
