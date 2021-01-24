    var card = new HeroCard()
    {
        Text = "Would you like me to help you?",
        Buttons = new List<CardAction>()
        {
           new CardAction(){ Title = "Yes", Type = ActionTypes.ImBack, Value = "Yes" },
           new CardAction(){ Title = "No", Type = ActionTypes.ImBack, Value = "No" },
        }
    }; 
    //To display the HeroCard, you need to send it as PromptOptions like this.
    return await stepContext.PromptAsync("dialogName",
                new PromptOptions
                {
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Yes", "No" }),
                    Prompt = (Activity)MessageFactory.Attachment(card.ToAttachment()),                             
                }, cancellationToken);
