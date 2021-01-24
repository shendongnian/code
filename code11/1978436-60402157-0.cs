    @page "/"
    @inject AuthenticationStateProvider AuthenticationStateProvider
    @using Microsoft.AspNetCore.Identity;
    @inject UserManager<IdentityUser> UserManager;
    <p>@Details</p>
    
    @code {
        private string Details { get; set; }
    
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
    
            if (user.Identity.IsAuthenticated)
            {
                var user = await _UserManager.FindByNameAsync(user.Identity.Name)
                Details = $"Your user phone # is {user.PhoneNumber}.";
            }
            else
            {
                Details = "The user is NOT authenticated.";
            }
        }
    }
