    if (context.Resource is AuthorizationFilterContext mvcContext)
    {
        var request = mvcContext.HttpContext.Request;
        request.EnableRewind();
        var reader = new StreamReader(request.Body);
        string body = reader.ReadToEnd();
        var model = JsonConvert.DeserializeObject(body, mvcContext.ActionDescriptor.Parameters.FirstOrDefault().ParameterType);
        JToken key;
        JObject.Parse(body).TryGetValue("key", StringComparison.InvariantCultureIgnoreCase, out key);
        request.Body.Seek(0, SeekOrigin.Begin);
    }
