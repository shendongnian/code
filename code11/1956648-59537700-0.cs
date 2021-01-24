    private static async Task<DialogTurnResult> TransportStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
    {
        string[] options = new[] { "Opción 1", "Opción 2" };
        return await stepContext.PromptAsync(nameof(ChoicePrompt), new PromptOptions
        {
            Choices = ChoiceFactory.ToChoices(options),
            Prompt = CreateHeroCardActivity(options),
            Style = ListStyle.None, // We're displaying the choices ourselves so we don't want ChoicePrompt to do it for us
        });
    }
    private static Activity CreateHeroCardActivity(IEnumerable<string> options)
    {
        var heroCard = new HeroCard
        {
            Title = "Documentation",
            Subtitle = "Microsoft Bot Framework Documentation",
            Images = new List<CardImage>
            {
                new CardImage("https://sec.ch9.ms/ch9/7ff5/e07cfef0-aa3b-40bb-9baa-7c9ef8ff7ff5/buildreactionbotframework_960.jpg"),
            },
            Buttons = options.Select(option => new CardAction(ActionTypes.ImBack, title: option, value: option))
                .Append(new CardAction(ActionTypes.OpenUrl, "Ir a a web", value: "https://docs.microsoft.com/bot-framework"))
                .ToList(),
        };
        return MessageFactory.Attachment(heroCard.ToAttachment()) as Activity;
    }
