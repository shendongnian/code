csharp
query = turnContext.Activity.Text;
You're defining `query` and then when/if you call `turnContext.Activity.RemoveRecipientMention()`, it changes `turnContext.Activity.Text`, but not `query`.
All you need to do is remove the mention before defining query:
csharp
public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
{
    if (turnContext.Activity.Type == ActivityTypes.Message)
    {
        turnContext.Activity.RemoveRecipientMention();
        
        query = turnContext.Activity.Text;
        if (turnContext.Activity.ChannelId == "msteams")
        {
            // I WANT TO ADD CODE HERE TO REMOVE THE @MENTIONS FROM QUESTION, BEFORE CALLING THE QNA Service.
            // incoming query ->  turnContext.Activity.Text value "<at> chat bot name </a> what is sharepoint? "
            // modified query -> turnContext.Activity.Text value "what is sharepoint? "       
        }
        var qnaResponse = await _services.QnAServices[QnAMakerKey].GetAnswersAsync(turnContext);
        if (qnaResponse[0].Score < .70)
        {
            await turnContext.SendActivityAsync("I'm having some trouble understanding what you mean. Could you please rephrase your question?", cancellationToken: cancellationToken);
        }
        else
        {
            await turnContext.SendActivityAsync(qnaResponse[0].Answer, cancellationToken: cancellationToken);
        }
    }
}  
