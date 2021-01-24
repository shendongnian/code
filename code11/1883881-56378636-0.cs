public class CustomValidationAttribute : ActionFilterAttribute
{
    private IAntiforgery _antiForgery { get; }
    public CustomValidationAttribute(IAntiforgery antiforgery)
    {
        _antiForgery = antiforgery;
    }
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isRequestValid = await this._antiForgery.IsRequestValidAsync(context.HttpContext);
        if (!isRequestValid)
        {
            //Add Code here if token is not valid
            return;         
        }
        await next();
    }
}
Add the attribute to your controller
[TypeFilter(typeof(CustomValidationAttribute))]
