     private async Task<DialogTurnResult> InterruptAsync(DialogContext innerDc,CancellationToken cancellationToken)
     {
     if (innerDc.Context.Activity.Type == ActivityTypes.Message)
     {
        var text = innerDc.Context.Activity.Text.ToLowerInvariant();
        switch (text)
        {
            case "help":
            case "?":
                await innerDc.Context.SendActivityAsync($"Show Help...", cancellationToken: cancellationToken);
                return new DialogTurnResult(DialogTurnStatus.Waiting);
            case "cancel":
            case "quit":
                await innerDc.Context.SendActivityAsync($"Cancelling", cancellationToken: cancellationToken);
                return await innerDc.CancelAllDialogsAsync();
        }
    }
    return null;
