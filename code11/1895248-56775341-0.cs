 lang-c#
public class ParameterConstraint : ActionMethodSelectorAttribute
{
    private readonly string _name;
    public ParameterConstraint(string name)
    {
        _name = name;
    }
    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        return !string.IsNullOrEmpty(routeContext.HttpContext.Request.Form[_name]);
    }
}
 lang-c#
[HttpPost("bar")]
[ParameterConstraint("someId")]
public IActionResult A([FromForm] string someId)
{
    ...
}
[HttpPost("bar")]
[ParameterConstraint("someData")]
public IActionResult B([FromForm] string someData)
{
    ...
}
