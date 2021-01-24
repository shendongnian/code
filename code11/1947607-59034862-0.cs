// Checked the database and user is legit so populate the claims
// Create the identity for the user. userList is var or list populated from database. userEmail is the user's email or some other identifier.
identity = new ClaimsIdentity(new[] {
    new Claim(ClaimTypes.Name, userList.fullname),
    new Claim(ClaimTypes.Role, userList.userrole),
    new Claim(ClaimTypes.NameIdentifier, userEmail),
}, CookieAuthenticationDefaults.AuthenticationScheme);
var principal = new ClaimsPrincipal(identity);
var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
return RedirectToAction("Index", "Home");
When you are in development you can do something like:
// You may need to inject Microsoft.AspNetCore.Hosting.IHostingEnvironment. I use .Net core 2.2 so not sure about 3.
if (env.EnvironmentName == "Development")
{
    // In Development so create "test" claim information and automatically authorize the user
    // Create the identity for the user
    identity = new ClaimsIdentity(new[] {
    new Claim(ClaimTypes.Name, "Test User"),
    new Claim(ClaimTypes.Role, "Tester"),
    new Claim(ClaimTypes.NameIdentifier, "tester@test.com"),
    }, CookieAuthenticationDefaults.AuthenticationScheme);
    // Populate the session user name
    HttpContext.Session.SetString(SessionUserName, userList.fullname);
    var principal = new ClaimsPrincipal(identity);
    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    return RedirectToAction("Index", "Home");
}
