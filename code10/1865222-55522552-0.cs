if (context.Response.StatusCode != 200 && context.Response.StatusCode != 206)
{
    ...
}
else
{
    context.Response.Body = body;
    newBody.Seek(0, SeekOrigin.Begin);
    await newBody.CopyTo(context.response.Body);
}
Or my personal preference is to create custom ErrorResult which implements IActionResult or inherits ObjectResult where You can format message using your object instead of string:
public class ErrorResult : ObjectResult
{
	public ErrorResult(MyError error)
		: base(error)
	{
		StatusCode = 400;
	}
	public override Task ExecuteResultAsync(ActionContext context)
	{
		var messageParser = context.HttpContext.RequestServices.GetService(typeof(IMessageParser));
		ContentTypes.Add(messageParser.GetFormat());
        <other modifications>
		return base.ExecuteResultAsync(context);
	}
and then return it in controllers
...
return new ErrorResult(new MyError(...));
...
