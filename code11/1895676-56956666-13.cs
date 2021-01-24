    try
    {
        await dc.ContinueDialogAsync(cancellationToken);
    }
    catch (Exception ex)
    {
        if (ex.Message == BotUtil.TooManyAttemptsMessage)
        {
            await turnContext.SendActivityAsync("Cancelling all dialogs...");
            await dc.CancelAllDialogsAsync(cancellationToken);
        }
        else
        {
            throw ex;
        }
    }
