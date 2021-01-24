public class HttpResponseMessageResult : IActionResult
{
	private readonly HttpResponseMessage _responseMessage;
	public HttpResponseMessageResult(HttpResponseMessage responseMessage)
	{
		_responseMessage = responseMessage;
	}
	public async Task ExecuteResultAsync(ActionContext context)
	{
		var objectResult = new ObjectResult(await _responseMessage.Content.ReadAsStreamAsync())
		{StatusCode = (int)_responseMessage.StatusCode};
		foreach (KeyValuePair<string, IEnumerable<string>> h in _responseMessage.Headers)
		{
			context.HttpContext.Response.Headers.TryAdd(h.Key, string.Join("", h.Value));
		}
		await objectResult.ExecuteResultAsync(context);
	}
}
  [1]: https://stackoverflow.com/a/42594823/7595191
