    public static bool SendPasswordMail(MembershipUser user, Control owner, string password)
    {
        var definition = new MailDefinition { BodyFileName = string.Concat(AccountRoot, "password.htm"), IsBodyHtml = true };
        var subject = "Your new password";
    
        var data = ExtendedData(DefaultData, subject, ApplicationConfiguration.ApplicationName);
    
        data.Add("<%Password%>", password);
    
        return definition.CreateMailMessage(user.Email, data, owner).Send(subject);
    }
