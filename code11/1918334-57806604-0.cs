    string body;
    using (var reader = new StreamReader(Request.Body)) {
        body = await reader.ReadToEndAsync();
    }
    if (body.Contains($"\"{nameof(EntityUpdate.Name)}\"", StringComparison.CurrentCultureIgnoreCase)) {
        //name was set
    }
