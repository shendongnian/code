    [HttpGet("[action]")]
    public  string GetClient()
    {
        var settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Error = (sender, args) =>
            {
                args.ErrorContext.Handled = true;
            },
        };
        return JsonConvert.SerializeObject(_context.Client, settings);
    }
