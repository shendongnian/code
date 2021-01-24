csharp
if (ctx.Request.Method.Equals("POST"))
{
    if (ctx.Request.Path.HasValue)
    {
        ctx.Request.EnableRewind();
        using (var ms = new MemoryStream())
        {
            ctx.Request.Body.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ctx.Request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(ms))
            {
                var jsonBody = reader.ReadToEnd();
                var body = JsonConvert.DeserializeObject<BaseRequest>(jsonBody);
                ctx.Token = body.Token;
                ctx.Request.Headers["Authorization"] = $"Bearer {body.Token}";
            }
        }
        return Task.CompletedTask;
    }
}
