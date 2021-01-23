        protected MailMessage GetNewUserMailMessage(string email, string username, string password, string loginUrl)
        {
            MailDefinition mailDefinition = new MailDefinition();
            mailDefinition.BodyFileName = "~/mailtemplates/newuser.txt";
            ListDictionary replacements = new ListDictionary();
            replacements.Add("<%username%>", username);
            replacements.Add("<%password%>", password);
            replacements.Add("<%loginUrl%>", loginUrl);
            return mailDefinition.CreateMailMessage(email, replacements, this);
        }
