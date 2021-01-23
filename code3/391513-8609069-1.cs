    protected void ErrorMail_Mailing(object sender, ErrorMailEventArgs e)
    {
        var elmahErrorId = e.Error.SessionVariables["ElmahId"].ToString();
        if (!string.IsNullOrEmpty(elmahErrorId))
            e.Mail.Subject = String.Format("{0}, see ELMAH_Error.ErrorID = {1}", e.Mail.Subject, elmahErrorId);
    }
