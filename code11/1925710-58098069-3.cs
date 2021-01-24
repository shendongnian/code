    public async Task Exec()
    {
        var cli = new HttpClient();
        var res = await cli.GetStringAsync("https://google.com").AwaitSafe((Exception ex) => throw ex);
        res = res.Replace("vv", "mm"); //use variable
    }
