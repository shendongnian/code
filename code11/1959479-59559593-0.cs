/Identity/Account/ExternalLogin?returnUrl=%2F&handler=Callback
this `Identity/Account/ExternalLogin` Page will sign in the user using the scheme of `Identity.Application` by sending a cookie in following way:
set-cookie: .AspNetCore.Identity.Application={the-cookie-here}
In other words, **the signin scheme here is `IdentityConstants.ApplicationScheme`  (i.e. `Identity.Application`)**
However, you've set the default authentication scheme as `Cookies` :
services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    ...
})
As a result, the `User` property within a RazorPage will always be authenticated with the scheme of `CookieAuthenticationDefaults.AuthenticationScheme`, which is different from the `Identity.Application` scheme. That's why your `User.Identity.IsAuthenticated` is always false.
To fix that issue, you could :
1. Approach 1: Configure a forward scheme for Cookies by :
    <pre>
    .AddCookie(options =&gt;{
        options.LoginPath = "/Account/Login/";
        <b>options.ForwardDefault = IdentityConstants.ApplicationScheme; </b>
    })
    </pre>
2. Approach 2: use the `IdentityConstants.ApplicationScheme` as the default scheme
3. Approach 3: Add `[Authorize(AuthenticationSchemes="Identity.Application")]` manually for page handler/page model:
    <pre>
    [Authorize(AuthenticationSchemes="Identity.Application")]
    </pre>
