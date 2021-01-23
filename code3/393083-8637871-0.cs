    var context = listener.GetContext();
    var request = context.Request;
    string text;
    using (var reader = new StreamReader(request.InputStream,
                                         request.ContentEncoding))
    {
        text = reader.ReadToEnd();
    }
    // Use text here
