    // Call the dialog and pass through options
    await dc.BeginDialogAsync(nameof(MyDialog), new { MyProperty1 = "MyProperty1Value", MyProperty2 = "MyProperty2Value" });
    
    // Retrieve the options
    public async Task<DialogTurnResult> MyWaterfallStepAsync(WaterfallStepContext waterfallStepContext, CancellationToken cancellationToken)
    {
        var passedInOptions = waterfallStepContext.Options;
    
        ...
    }
