csharp
if (turnContext.Activity.Text == "fakeConversationUpdate")
{
    var fakeTurnContext = new TurnContext(turnContext.Adapter, MessageFactory.Text(string.Empty));
    fakeTurnContext.Activity.AsConversationUpdateActivity();
    fakeTurnContext.Activity.Type = ActivityTypes.ConversationUpdate;
    fakeTurnContext.Activity.MembersAdded = new List<ChannelAccount>()
    {
        new ChannelAccount()
        {
            Id = "fakeUserId",
            Name = "fakeUserName"
        }
    };
    await OnConversationUpdateActivityAsync(fakeTurnContext as ITurnContext<IConversationUpdateActivity>, cancellationToken);
}
Then to debug, you just write "fakeConversationUpdate" (which you can change/customize) to the bot in chat and it will send your `fakeTurnContext` (which you can change/customize) through `OnConversationUpdateActivityAsync()`
