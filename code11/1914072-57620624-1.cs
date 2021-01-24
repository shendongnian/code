    public static void MyCallingMethod(...)
    {
        ...
        DataDto getData = null;
        Task.Run(async () =>
        {
            getData = await CallApi("<api-url>", token.access_token).ConfigureAwait(false);
        }).GetAwaiter().GetResult(); 
        ...
    }
