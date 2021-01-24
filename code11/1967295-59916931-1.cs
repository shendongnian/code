public class MyModel
{
     [JsonProperty("screen_width")]
     [Required(ErrorMessage = "Required width")]
     [DisplayName("screen_width")]
     public string ScreenWidth { get; set; }  
}
But this on it's own will not work. You need to disable the internal model state filter.
public void ConfigureServices(IServiceCollection services)  
    {  
        ...  
        services.Configure<ApiBehaviorOptions>(options =>  
            {  
                options.SuppressModelStateInvalidFilter = true;  
            });  
        ...  
    }  
And then, create another filter
public class DisplayNameValidationFilterAttribute : ActionFilterAttribute  
{  
    public override void OnActionExecuting(ActionExecutingContext context)  
    {  
        if (context.ModelState.ErrorCount > 0)  
        {  
            var modelType = context.ActionDescriptor.Parameters  
                .FirstOrDefault(p => p.BindingInfo.BindingSource.Id.Equals("Body", StringComparison.InvariantCultureIgnoreCase))?.ParameterType; //Get model type  
  
            var expandoObj = new ExpandoObject();  
            var expandoObjCollection = (ICollection<KeyValuePair<String, Object>>)expandoObj; //Cannot convert IEnumrable to ExpandoObject  
  
            var dictionary = context.ModelState.ToDictionary(k => k.Key, v => v.Value)  
                .Where(v => v.Value.ValidationState == ModelValidationState.Invalid)  
                .ToDictionary(  
                k =>  
                {  
                    if (modelType != null)  
                    {  
                        var property = modelType.GetProperties().FirstOrDefault(p => p.Name.Equals(k.Key, StringComparison.InvariantCultureIgnoreCase));  
                        if (property != null)  
                        {  
                            //Try to get the attribute  
                            var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault()?.DisplayName;  
                            return displayName ?? property.Name;  
                        }  
                    }  
                    return k.Key; //Nothing found, return original vaidation key  
                },  
                v => v.Value.Errors.Select(e => e.ErrorMessage).ToList() as Object); //Box String collection  
            foreach (var keyValuePair in dictionary)  
            {  
                expandoObjCollection.Add(keyValuePair);  
            }  
            dynamic eoDynamic = expandoObj;  
            context.Result = new BadRequestObjectResult(eoDynamic);  
        }  
        base.OnActionExecuting(context);  
    }  
}  
Now just use the following:
public class MyController
{
    [Route("/api/v1.0/test")]
    [DisplayNameValidationFilter]  
    [HttpPatch]
    public async Task<IActionResult> SomeAction([FromBody] MyModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    }
}
  [1]: https://dejanstojanovic.net/aspnet/2018/november/using-displayname-attribute-for-model-validation-output-in-aspnet-mvc-core/
