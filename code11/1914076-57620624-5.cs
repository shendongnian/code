    public static void MyCallingMethod(...)
    {
        ...
        string getData = null;
        Task.Run(async () =>
        {
            getData = await CallApi("<api-url>", token.access_token).ConfigureAwait(false);
        }).GetAwaiter().GetResult(); 
        ...
    }
