csharp
public class CancelCamelCaseResolverConfigurationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
        switch(context.Result){
            case JsonResult j:
                var result = new ObjectResult(j);
                ChangeFormatting(result);
                break;
            case ObjectResult o:
                ChangeFormatting(o);
                break;
            default:
                return;
        }
    }
    private void ChangeFormatting(ObjectResult result){
        if (result == null){ return; }
        result.Formatters.Clear();
        result.Formatters.Add(new JsonOutputFormatter(
            new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                ContractResolver = new DefaultContractResolver()
            }, ArrayPool<char>.Shared)
        );
    }
}
