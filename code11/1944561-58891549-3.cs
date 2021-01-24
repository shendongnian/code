    protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        await base.HandleChallengeAsync(properties);
    
        Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        var errorObj = ErrorResponseDTO.CreateInvalidApiKey();
    
        await Context.WriteModelAsync(errorObj);
    }
