 lang-cs
[HttpGet]
public async Task<HttpResponseMessage> Get()
{
	var response = Request.CreateResponse(HttpStatusCode.OK);
	response.Content = new PushStreamContent(async (stream, content, context) =>
	{
		await _writer.WriteAsync(stream);
		stream.Close();
	}, "application/json");
	return response;
}
