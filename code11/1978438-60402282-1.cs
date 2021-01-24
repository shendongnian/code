     @page "/"
     @using Microsoft.AspNetCore.Components.Authorization
     @inject AuthenticationStateProvider AuthenticationStateProvider
     <button @onclick="LogUsername">Write user info to console</button>
     @code {
         private async Task LogUsername()
        {
             var authState = await 
             AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        if (user.Identity.IsAuthenticated)
        {
            Console.WriteLine($"{user.Identity.Name} is authenticated.");
        }
        else
        {
            Console.WriteLine("The user is NOT authenticated.");
        }
    }
