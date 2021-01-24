    @if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))) 
    {
        <partial name="_LogOutForm"/>
    }
    else
    {
        <partial name="_SignInForm"/>
    }
