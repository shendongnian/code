c#
private static async Task DisplayOptionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
{
    var card = new HeroCard
    {
        Text = "You can upload an image or select one of the following choices",
        Buttons = new List<CardAction>
        {
            new CardAction(ActionTypes.ImBack, title: "1. Green", value: "1"),
            new CardAction(ActionTypes.ImBack, title: "2. Blue", value: "2"),
            new CardAction(ActionTypes.ImBack, title: "3. Red", value: "3"),
        },
    };
    var reply = MessageFactory.Attachment(card.ToAttachment());
    await turnContext.SendActivityAsync(reply, cancellationToken);
}
