    if (userIsValid(username, pwd)) // some validation call
    {
        bool isAdmin = checkAdmin(username); // some admin check
        HttpCookie ticket = FormsAuthentication.GetAuthCookie(username, false);
        AuthTools.ReWriteAuthTicket(ticket, isAdmin.ToString());
    }
