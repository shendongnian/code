 C#
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
namespace Name_Of_Project.ActionFilters
{   
    // This filter can be applied to classes to do the automatic token validation.
    // This filter also handles the model validation.
    // inspiration https://code-maze.com/action-filters-aspnetcore/
    public class ValidationFilterAttribute: IActionFilter
    {
        // passing variables into an action filter https://stackoverflow.com/questions/18209735/how-do-i-pass-variables-to-a-custom-actionfilter-in-asp-net-mvc-app    
        private readonly ILogger<ValidationFilterAttribute> _logger;
        public ValidationFilterAttribute(ILogger<ValidationFilterAttribute> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //executing before action is called
            // this should only return one object since that is all an API allows. Also, it should send something else it will be a bad request
            var param = context.ActionArguments.SingleOrDefault();
            if (param.Value == null)
            {
                _logger.LogError("Object sent was null. Caught in ValidationFilterAttribute class.");
                context.Result = new BadRequestObjectResult("Object sent is null");
                return;
            }
    
            // the param should be named request (this is the input of the action in the controller)
            if (param.Key == "request")
            {
                Newtonsoft.Json.Linq.JObject jsonObject = Newtonsoft.Json.Linq.JObject.FromObject(param.Value);
                
                // case sensitive btw
                string token = jsonObject["Token"].ToString();
                // check that the token is valid
                if (token == null || token != "1234")
                {
                    _logger.LogError("Token object is null or incorrect.");
                    context.Result = new UnauthorizedObjectResult("");
                    return;
                }
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // executed after action is called
        }
    }
}
Then my `Startup.cs`
 C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                       
    // Adding an action Filter
    services.AddScoped<ValidationFilterAttribute>();
}
Then I can add it to my controller.
C#
using Name_Of_Project.ActionFilters;
namespace Name_Of_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomethingController : ControllerBase
    {
        // POST api/something
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public ActionResult GetSomething(SomethingRequest request)
        {
            var something= request.Something;
            var token = request.Token;
    }
}
Because I want to reuse this action filter many times, I need to figure out a way to pass in a parameter for the null check (could have many different objects coming in under the name of "request" that need to check). [This is the answer][4] I will be looking to for that portion of the solution.
  [1]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2
  [2]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.2#action-filters
  [3]: https://code-maze.com/action-filters-aspnetcore/
  [4]: https://stackoverflow.com/questions/4348071/how-to-pass-parameters-to-a-custom-actionfilter-in-asp-net-mvc-2
