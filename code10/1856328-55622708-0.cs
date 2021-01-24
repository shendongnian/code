cs
  [Route("api/messages")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly IBotFrameworkHttpAdapter Adapter;
        private readonly IBot Bot;
        public BotController(IBotFrameworkHttpAdapter adapter, IBot bot)
        {
            Adapter = adapter;
            Bot = bot;
        }
        [HttpPost]
        public async Task PostAsync()
        {
            Request.EnableBuffering();
            using (var buffer = new MemoryStream())
            {
                await Request.Body.CopyToAsync(buffer);
                buffer.Position = 0L;
                using (var bodyReader = new JsonTextReader(new StreamReader(buffer, Encoding.UTF8)))
                {
                    Debug.Print(BotMessageSerializer.Deserialize(bodyReader).ToString());
                    buffer.Position = 0L;
                }
            }
            Request.Body.Position = 0;
  
          await Adapter.ProcessAsync(Request, Response, Bot);
        }
    }
This should provide more information on what type of message is being sent to the bot.  My guess is that it has something to do with a Facebook Messenger specific web hook you have subscribed to.  For instance, I don't think 'message_echoes' are currently sent to the bot with a .From or conversation.Id.  However, we have recently modified our Connector Service to include these: the release should be within the next few weeks.
  [1]: https://github.com/Microsoft/BotBuilder-Samples/blob/samples-work-in-progress/samples/csharp_dotnetcore/13.core-bot
