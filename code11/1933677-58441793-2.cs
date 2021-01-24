    foreach (var userID in recipientUserIds)
    {
        var userInfo = GetUserInfo(userID);
        // Basic validation on length
        var email = userInfo?.Email1?.Trim();
        if (string.IsNullOrEmpty(email) || email.Length < 3) continue;
        // Basic validation on '@' character position
        var atIndex = email.IndexOf('@');
        if (atIndex < 1 || atIndex == email.Length - 1) continue;
        // Let try/catch handle the rest, because email addresses are complicated
        MailAddress to;
        try
        {
            to = new MailAddress(email, $"{userInfo.FirstName} {userInfo.LastName}");
        }
        catch (FormatException)
        {
            continue;
        }
        using (MailMessage message = new MailMessage(from, to))
        {
            // populate message and send email here
        }
    }
