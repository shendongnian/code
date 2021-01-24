 c#
services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Users/Login";
    // ...
    options.Cookie = new CookieBuilder
    {
        // ...
        IsEssential = true //  this cookie will always be stored regardless of the user's consent
    };
});
