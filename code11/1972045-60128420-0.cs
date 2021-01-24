    static async Task Main(string[] args)
    {
        TelegramBotClient client = new TelegramBotClient(ApiKey);
        await client.SendTextMessageAsync(MyChatId, "Hello World");
    }
