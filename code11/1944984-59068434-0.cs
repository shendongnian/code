    private async Task<bool> CheckChoicePromptValidator(PromptValidatorContext<FoundChoice> promptContext, CancellationToken cancellationToken)
        {
            if(promptContext.Recognized.Succeeded)
            {
                return await Task.FromResult(true);
            }
            else
            {
                var userInput = promptContext.Context.Activity.Text;
                // You can use LUIS instead of switch case
                switch(userInput.ToLower())
                {
                    case "cancel":
                    case "quit":
                    case "reset":
                        await promptContext.Context.SendActivityAsync(MessageFactory.Text("Cancelling!"), cancellationToken);
                        var dc = await BotUtil.Dialogs.CreateContextAsync(promptContext.Context, cancellationToken);
                        await dc.CancelAllDialogsAsync(cancellationToken);
                        return await Task.FromResult(false);
                }
            }
        }
