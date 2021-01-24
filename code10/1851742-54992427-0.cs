    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message) {
                // Check for selected flag
                if (turnContext.Activity.Text.Split(' ')[0] == "selected:") {
                    await turnContext.SendActivityAsync($"You {turnContext.Activity.Text}");
                } else {
                    var reply = turnContext.Activity.CreateReply();
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(GetHeroCard().ToAttachment());
                    
                    await turnContext.SendActivityAsync(reply, cancellationToken);
                }
            }
        }
        private static HeroCard GetHeroCard()
        {
            var buttons = new List<CardAction>();
            buttons.Add(new CardAction(ActionTypes.PostBack, "operating group", value: "selected: operating group"));
            buttons.Add(new CardAction(ActionTypes.PostBack, "geo", value: "selected: geo"));
            buttons.Add(new CardAction(ActionTypes.PostBack, "technology", value: "selected: technology"));
            buttons.Add(new CardAction(ActionTypes.PostBack, "themes", value: "selected: themes"));
            var heroCard = new HeroCard
            {
                Title = "BotFramework Hero Card",
                Subtitle = "Microsoft Bot Framework",
                Images = new List<CardImage> {},
                Buttons = buttons,
            };
            return heroCard;
        }  
    }
