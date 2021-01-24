    var choices = new List<Choice>
    {
        new Choice()
        {
            Value = "itm001",
            Synonyms = new List<string> {"hotdog", "hot dog"},
            Action = new CardAction()
            {
                Type = ActionTypes.ImBack,
                Title = "Buy a hotdog",
                Value = "hotdog"
            }
        },
        new Choice()
        {
            Value = "itm002",
            Synonyms = new List<string> {"bulldog", "bull dog"},
            Action = new CardAction()
            {
                Type = ActionTypes.ImBack,
                Title = "Buy a bulldog",
                Value = "bulldog"
            }
        },
    };
    
    return await stepContext.PromptAsync("myPrompt",
        new PromptOptions {
            Prompt = MessageFactory.Text("What can I offer you?"),
            RetryPrompt = MessageFactory.Text("I dont have that"),
            Choices = choices,
            Style = ListStyle.HeroCard
        }, cancellationToken);
