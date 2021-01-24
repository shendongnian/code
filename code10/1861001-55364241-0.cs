    public MultiTurnPromptsBot(MultiTurnPromptsBotAccessors accessors)
    {
        ...
        // This array defines how the Waterfall will execute.
        var waterfallSteps = new WaterfallStep[]
        {
            PromptForLocation,
            CaptureLocation,
        };
        ...
        // Add named dialogs to the DialogSet. These names are saved in the dialog state.
        _dialogs.Add(new WaterfallDialog("details", waterfallSteps));
        _dialogs.Add(new TextPrompt("location", LocationPromptValidatorAsync));
    }
