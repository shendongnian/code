    static Task<string> PrepareAwaitable(int x)
    {
        return Task.Factory.StartNew<string>(() =>
        {
            return "Howdy " + x.ToString();
        });
    }
