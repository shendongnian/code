    private static async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await stepContext.PromptAsync(
            "choicePrompt",
            new PromptOptions
            {
                Prompt = MessageFactory.Text("Select an Action"),
                Choices = new List<Choice> { new Choice("Yes"), new Choice("No") },
            });
    }
    
    private static async Task<DialogTurnResult> SecondStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        var k = ((FoundChoice)stepContext.Result).Value.ToString();
        return await stepContext.NextAsync();
    }
