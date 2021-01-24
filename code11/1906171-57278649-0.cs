using Microsoft.AspNetCore.Mvc;
namespace ApiVersioning.Controllers.Api.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("validforboth")]
        public ActionResult<string> ValidForBoth()
        {
            return "Version 1 API";
        }
        [HttpGet]
        [Route("validversion1only")]
        public ActionResult<string> ValidVersion1Only()
        {
            return "This endpoint won't exist on API version 2 - try it";
        }
    }
}
namespace ApiVersioning.Controllers.Api.V2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("validforboth")]
        public ActionResult<string> ValidForBoth()
        {
            return "Version 2 API";
        }
        [HttpGet]
        [Route("validversion2only")]
        public ActionResult<string> ValidVersion2Only()
        {
            return "This endpoint won't exist on API version 1 - try it";
        }
    }
}
We've got two classes, one for each version of the API annotated as version 1.0 and version 2.0. We configure the middleware exactly as you did - making version 2.0 the default:
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        services
                .AddApiVersioning(o =>
                {
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                    o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
                    o.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader(), new HeaderApiVersionReader("api-version"));
                });
    }
   
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMvc();
    }
}
Now we try calling the two API versions just using Chrome and GET requests.
## Version 1 responses (`?api-version=1.0` in query string)
**/api/values/validforboth** returns `Version 1 API`
**/api/values/validversion1only** returns `This endpoint won't exist on API version 2 - try it`
**/api/values/validversion2only** returns HTTP 400 with the following JSON body:
{
  "error": {
    "code": "UnsupportedApiVersion",
    "message": "The HTTP resource that matches the request URI 'http://localhost:55575/api/values/validversion2only' does not support the API version '1.0'.",
    "innerError": null
  }
}
## Version 2 responses (either omitting `?api-version=1.0`, or specifying 2.0 explicitly)
**/api/values/validforboth** returns `Version 2 API`
**/api/values/validversion1only** returns HTTP 400 with the following JSON body:
{
  "error": {
    "code": "UnsupportedApiVersion",
    "message": "The HTTP resource that matches the request URI 'http://localhost:55575/api/values/validversion1only' is not supported.",
    "innerError": null
  }
}
**/api/values/validversion2only** returns `This endpoint won't exist on API version 1 - try it`
The clients of your version 1 API will see a 400 if they try to hit an endpoint defined only in version 2 - similarly, clients of your version 2 API will see a 400 if they try to hit an endpoint defined only in version 1.
