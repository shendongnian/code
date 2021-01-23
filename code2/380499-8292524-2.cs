    public static IDisposable RoleAccess(
        this HtmlHelper helper, 
        UserInfo user, 
        RoleAccessType role
    )
    {
        var style = "display:none;";
        if (user.HasAccess(role))
        {
            style = "display:block;";
        }
        var writer = htmlHelper.ViewContext.Writer;
        writer.WriteLine("<div class=\"role_" + role.ToString() + "\" style=\"" + style + "\">");
        return new RoleContainer(writer);
    }
