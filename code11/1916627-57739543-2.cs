    public class Bot : IBot {
        private readonly ITelegramBotClient _botClient;
        private readonly BotConfig botConfig;
        private readonly IAccount _account;
        private Task setWebhookTask;
        public Bot(IOptions<BotConfig> options, ITextCommands xtCommands, IAccount account) {
            botConfig = options.Value;
            _account = account;
            _botClient = new TelegramBotClient(botConfig.Token);
            setWebhookTask = SetWebhookAsync();
        }
        private Task SetWebhookAsync() =>
            _botClient.SetWebhookAsync(
                string.Format(botConfig.WebhookHost, botConfig.WebhookUrl)
            );
        public async Task HandleTextCommandAsync(Message message) {
            await setWebhookTask;
            bool regResult = await _account.TryRegisterUserAsync(message.From);
            // to do
        }
    }
