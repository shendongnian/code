    @inject IAuthorizationService AuthorizationService
    <button @onclick="@DoSomething">Do something important</button>
    @code {
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    private async Task DoSomething()
    {
        var user = (await authenticationStateTask).User;
        if ((await AuthorizationService.AuthorizeAsync(user, "CanReadNamePolicy"))
            .Succeeded)
        {
            // Perform an action only available to users satisfying the 
            // 'CanReadNamePolicy' policy.
        }
    }
    }
