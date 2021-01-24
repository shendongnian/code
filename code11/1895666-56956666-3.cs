    try
    {
        await dc.ContinueDialogAsync(cancellationToken);
    }
    catch (Exception ex)
    {
        if (ex.Source == TestDialog.ID)
        {
            await turnContext.SendActivityAsync("Cancelling all dialogs...");
            await dc.CancelAllDialogsAsync(cancellationToken);
        }
        else
        {
            throw ex;
        }
    }
