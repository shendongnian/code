    private Task<bool> ValidateAsync(PromptValidatorContext<string> promptContext, CancellationToken cancellationToken)
    {
        if (promptContext.AttemptCount > 3 || IsCorrectPassword(promptContext.Context.Activity.Text))
        {
            // valid user input
            // or continue to next step anyway because of too many attempts
            return Task.FromResult(true);
        }
        // invalid user input
        // when there haven't been too many attempts
        return Task.FromResult(false);
    }
