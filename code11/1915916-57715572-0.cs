    public class NotifiController : ControllerBase
        {
    
            public NotifiController(IBotFrameworkHttpAdapter adapter, IStorage storage, MainDialog dialog, ConversationState conversationState, ILogger<NotifiController> logger)
            {
                _adapter = (BotFrameworkHttpAdapter)adapter ?? throw new ArgumentNullException(nameof(adapter));
                _storage = storage ?? throw new ArgumentNullException(nameof(storage));
                _mainDialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
                _conversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
                _appId = Guid.NewGuid().ToString();
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }
        }
