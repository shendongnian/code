    if (results.Status == DialogTurnStatus.Empty)
    {
        // A prompt dialog can be started directly on the DialogContext. The prompt text is given in the PromptOptions.
        await dialogContext.PromptAsync(
            "name",
            new PromptOptions { Prompt = MessageFactory.Text("Please enter your name.") },
            cancellationToken);
    }
    
    // We had a dialog run (it was the prompt). Now it is Complete.
    else if (results.Status == DialogTurnStatus.Complete)
    {
        // Check for a result.
        if (results.Result != null)
        {
            // Finish by sending a message to the user. Next time ContinueAsync is called it will return DialogTurnStatus.Empty.
            await turnContext.SendActivityAsync(MessageFactory.Text($"Thank you, I have your name as '{results.Result}'."));
        }
    }
    }
