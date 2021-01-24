    @using Microsoft.AspNetCore.Identity
    @inject SignInManager<ApplicationUser> SignInManager
    @inject UserManager<ApplicationUser> UserManager
    @{
       ApplicationUser applicationUser = await UserManager.GetUserAsync(User); // Here `User` is the claim principal
       var voornaam = applicationUser.Voornaam;
    }
