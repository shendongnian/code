    @if(Model.IsAuthenticated)
    {
        "Hello " + User.Identity.GetUserName()
    }
    else 
    {
        <ul class="nav navbar-nav navbar-right">
            <li style="color: white; line-height: 50px;">
            <li>@Html.ActionLink("Login", "Login.aspx", "Login.aspx")</li>
            <li>@Html.ActionLink("Register", "Register.aspx", "Register.aspx")</li>
        </ul>
    }
