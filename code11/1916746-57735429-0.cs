    public class TextMessageClient : IDisposable
    {
        bool disposed = false;
        private Telegram.Bot.TelegramBotClient client;
        public TextMessageClient()
        {
            //Write your own logic to get the token
            //Or accept the token as an argument of constructor.
            var token = Guid.NewGuid().ToString();
            client = new Telegram.Bot.TelegramBotClient(token);
        }
        public TextMessageClient(string token)
        {
            client = new Telegram.Bot.TelegramBotClient(token);
        }
        public async Task<Telegram.Bot.Types.Message> SendMessageAsync(string chatId, string message, string, IReplyMarkup keyboard, )
        {
            return await client.SendMessageAsync(chatId, message, replyMarkup: keyboard, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                client = null;
            }
            disposed = true;
        }
    }
