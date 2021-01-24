    public static void Main(ref string msg)
    {
        msg = Foo(msg);
    }
    public static string Foo(string msg)
    {
        return Task.Run(async ()=> await DoAsyncWork(msg)).Result;
    }
    async Task<string> DoAsyncWork(string msg)
    {
        string result = await DoMaybeSomeOtherTask(msg);
        return result;
    }
