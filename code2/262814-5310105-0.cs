    @if(Request.IsAuthenticated) {        
        using (Html.BeginForm("LogOff", "Account"))
        {
            <input type="submit" name="login" value="Log Off" />
        }
    }
    else
    {
        @:[ @Html.ActionLink("Log On", "LogOn", "Account") ]
    }
