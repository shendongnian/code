    private static async Task<DialogTurnResult> PromptForLocation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        Activity reply = stepContext.Context.Activity.CreateReply();
            var heroCard = new HeroCard
        {
            Title = "Please choose a location.",
            Buttons = new List<CardAction> { new CardAction(ActionTypes.PostBack, "Redmond", value: "Redmond"), 
                                                new CardAction(ActionTypes.PostBack, "Bellevue", value: "Bellevue"), 
                                                new CardAction(ActionTypes.PostBack, "Seattle", value: "Seattle") },
        };
        reply.Attachments = new List<Attachment>() { heroCard.ToAttachment() };
        var options = new PromptOptions()
            {
            Prompt = reply,
            RetryPrompt = MessageFactory.Text("Sorry, please choose a location from the list.")
            };
        return await stepContext.PromptAsync("name", options, cancellationToken);
    }
