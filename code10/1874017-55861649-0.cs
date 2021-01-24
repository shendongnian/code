    [Authorize(Policy = "JustDevelopersPolicy")]
    public async Task<void> PrivateAPI()
    {
    ...
    }
