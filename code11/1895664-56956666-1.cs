    private Task<bool> ValidateAsync(PromptValidatorContext<string> promptContext, CancellationToken cancellationToken)
    {
        if (promptContext.AttemptCount > 3 || IsCorrectPassword(promptContext.Context.Activity.Text))
        {
            // valid user input
            return Task.FromResult(true);
        }
        // invalid user input
        return Task.FromResult(false);
    }
