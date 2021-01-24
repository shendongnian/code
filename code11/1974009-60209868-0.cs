    public void Init()
    {
    	RecurringJob.AddOrUpdate("Generate", () => Generate("Hello"), Cron.Weekly(DayOfWeek.Monday, 10, 00));
    	RecurringJob.AddOrUpdate("Generate M", () => Generate("Goodbye"), Cron.Weekly(DayOfWeek.Monday, 12, 00));
    }
    
    public async Task Generate(string message)
    {
    	HttpClient httpClient = new HttpClient();
    	await httplClient.PostAsync(new Uri("theURL"), new StringContent(message);
    }
