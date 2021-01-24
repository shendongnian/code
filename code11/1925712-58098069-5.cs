    public async Task Exec()
    {
        var cli = new HttpClient();
        var result = await cli.GetStringAsync("https://google.com").AwaitSafe((Exception ex) => throw ex);
        if (result.Success)
        {
            //good
        }
        else
        {
            //bad
        }
    }
