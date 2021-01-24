    public Task<bool> LocationPromptValidatorAsync(PromptValidatorContext<string> promptContext, CancellationToken cancellationToken)
    {
        var activity = promptContext.Context.Activity;
        var location = activity.Entities?.FirstOrDefault(e => e.Type == "Place");
        if (location != null) {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }  
