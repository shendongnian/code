csharp
protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
{
    if (turnContext.Activity.Text.Contains("end") || turnContext.Activity.Text.Contains("stop"))
    {
        // Send End of conversation at the end.
        await turnContext.SendActivityAsync(MessageFactory.Text($"ending conversation from the skill..."), cancellationToken);
        var endOfConversation = Activity.CreateEndOfConversationActivity();
        endOfConversation.Code = EndOfConversationCodes.CompletedSuccessfully;
        await turnContext.SendActivityAsync(endOfConversation, cancellationToken);
    }
[...]
