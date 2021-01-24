    async (stepContext, cancellationToken) =>
    {
        if (IsCorrectPassword(stepContext.Context.Activity.Text))
        {
            return await stepContext.NextAsync(null, cancellationToken);
        }
        else
        {
            await stepContext.Context.SendActivityAsync("Cancelling all dialogs...");
            return await stepContext.CancelAllDialogsAsync(cancellationToken);
        }
    },
