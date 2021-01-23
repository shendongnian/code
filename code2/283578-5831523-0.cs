    public static TResult Execute<TResult>(Func<ServiceClient, TResult> proxy)
    {
        using (var client = new ServiceClient())
        {
            return proxy(client);
        }
    }
