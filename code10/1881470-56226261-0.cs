csharp
using Microsoft.Bot.Connector.Authentication;
public async Task<IActionResult> Get()
{
    MicrosoftAppCredentials.TrustServiceUrl("https://sms.botframework.com/"); 
    var conversationReference = new ConversationReference {
        User = new ChannelAccount { Id = "<USER_NUMBER>" },
        Bot = new ChannelAccount { Id = "<BOT_NUMBER>" },
        Conversation = new ConversationAccount { Id = "<USER_NUMBER>" },
        ServiceUrl = "https://sms.botframework.com/"
    };
    await ((BotAdapter)_adapter).ContinueConversationAsync(_appId, cr, BotCallback, default(CancellationToken));
    // Let the caller know proactive messages have been sent
    return new ContentResult()
    {
        Content = "<html><body><h1>Proactive messages have been sent.</h1></body></html>",
        ContentType = "text/html",
        StatusCode = (int)HttpStatusCode.OK,
    };
}
private async Task BotCallback(ITurnContext turnContext, CancellationToken cancellationToken)
{
    await turnContext.SendActivityAsync("proactive hello");
}
For more details on sending proactive messages, take a look at the [Proactive Message sample](https://github.com/microsoft/BotBuilder-Samples/tree/master/samples/csharp_dotnetcore/16.proactive-messages).
Hope this helps.
