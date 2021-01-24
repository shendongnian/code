    protected virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> message)
    {
        T result;
        if (this.TryParse(await message, out result))
        {
            context.Done(result);
        }
        else
        {
            --promptOptions.Attempts;
            if (promptOptions.Attempts >= 0)
            {
                await context.PostAsync(this.MakePrompt(context, promptOptions.Retry ?? promptOptions.DefaultRetry, promptOptions.Choices?.Keys.ToList().AsReadOnly(), promptOptions.Descriptions, promptOptions.RetrySpeak ?? promptOptions.DefaultRetrySpeak));
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                //too many attempts, throw.
                await context.PostAsync(this.MakePrompt(context, promptOptions.TooManyAttempts));
                throw new TooManyAttemptsException(promptOptions.TooManyAttempts);
            }
        }
    }
