app.UseMiddleware<RemoveInvalidFormKeysMiddleware>();
app.UseMvc();
This middleware will rewrite "invalid" keys in Request.Forms
public class RemoveInvalidFormKeysMiddleware
{
	private readonly RequestDelegate next;
	public RemoveInvalidFormKeysMiddleware(RequestDelegate next)
	{
		this.next = next;
	}
	public async Task Invoke(HttpContext context)
	{
		Dictionary<string, StringValues> validForm = new Dictionary<string, StringValues>();
		foreach (var form in context.Request.Form)
		{
			if (!form.Key.Contains('&'))
			{
				validForm.Add(form.Key, form.Value);
				continue;
			}
			string key = form.Key.Substring(form.Key.LastIndexOf('&') + 1);
			if (!string.IsNullOrWhiteSpace(key))
			{
				validForm.Add(key, form.Value);
			}
		}
		context.Request.Form = new FormCollection(validForm);
		await next(context);
	}
}
Then we can keep the rest of the logic without change anything else
[HttpPost("user")]
public AcceptedResult UserNotificationListener([FromForm]WebHookDto<UserNotificationDto> request)
{
    // some code that validate the query or throw exception
}
Hope it helps, Rémi
