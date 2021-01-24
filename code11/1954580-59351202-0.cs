    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        if (turnContext.Activity.Text.Equals("give me a choice"))
        {
            var adaptiveJsonString = "{\"$schema\":\"https://adaptivecards.io/schemas/adaptive-card.json\",\"type\":\"AdaptiveCard\",\"version\":\"1.0\",\"body\":[{\"type\":\"TextBlock\",\"text\":\"choose an amount\",\"size\":\"large\"}],\"actions\":[{\"type\":\"Action.Submit\",\"title\":\"total statement balance $29.99\",\"data\":\"29.99\"},{\"type\":\"Action.Submit\",\"title\":\"total outstanding balance $35.00\",\"data\":\"35.00\"}]}";
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveJsonString),
            };
            await turnContext.SendActivityAsync(MessageFactory.Attachment(adaptiveCardAttachment), cancellationToken);
        }
        else {
            await turnContext.SendActivityAsync(MessageFactory.Text("You inputed : " + turnContext.Activity.Text), cancellationToken);
        }
        
    }
