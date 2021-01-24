 [ValidateModel]
 public IActionResult Index(Test t)
 {
    return View(t);
 }
public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            
        }
        base.OnActionExecuting(context);
    }
}
