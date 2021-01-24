    //using Microsoft.AspNetCore.Authentication;
    //using Microsoft.AspNetCore.Mvc;
    // Remove cookie
    await HttpContext.SignOutAsync("Cookies");
    // Signout oidc
    await HttpContext.SignOutAsync("oidc");
