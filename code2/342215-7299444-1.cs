    var data = new[]
    {
        new ChatData { Username = "bob", Message = "hey guys" },
        new ChatData { Username = "david", Message = "hey you" },
        new ChatData { Username = "jill", Message = "wait what" },
    };
    return Response.AsJson(data);
