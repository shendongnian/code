    public async static Task<string> GetRequestBody(this HttpActionContext actionContext)
    {
        var bodyStream = await actionContext.Request.Content.ReadAsStreamAsync();
        bodyStream.Position = 0;
        var bytes = new byte[bodyStream.Length];
        await bodyStream.ReadAsync(bytes, 0, bytes.Length);
        return Encoding.ASCII.GetString(bytes);
    }
