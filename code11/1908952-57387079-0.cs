    [HttpPut("api/Person/{id}")]
    public IActionResult Put(string id, [FromBody]Person person)
    {
        // ... Do normal stuff
        return Ok();
    }
        
        
    public class Person
    {
    	[ValidateId]
        public string Id { get; set; }
        public string Name { get; set; }
                  
    }
        
    
    public sealed class ValidateId : ValidationAttribute
    {
    	protected override ValidationResult IsValid(object id, ValidationContext validationContext)
        {
    		var httpContextAccessor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var routeData = httpContextAccessor.HttpContext.GetRouteData();
            var idFromUrl = routeData.Values["id"];
        
            if (id.Equals(idFromUrl))
            {
    			return ValidationResult.Success;
            }
            else
            {
    			return new ValidationResult("Id mismatch!");
            }
        }
    }
        
        
    // In the Startup class add the IHttpContextAccessor
    
    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddHttpContextAccessor();
        // ...
    }
