    public partial class Email
    {
    /// <summary>
    /// Generic Email method used to send email through SendGrid
    /// </summary>
    /// <param name="ToAddressName">ToAddress, DisplayName</param>
    /// <param name="FromAddress">Email address of sender</param>
    /// <param name="FromName">Display Name of sender</param>
    /// <param name="SendCopy">Send BCC to FromAddress</param>
    public void SendEmail(Dictionary<string, string> toAddressName,
                          String fromAddress, String fromName,
                          String subject, String message,
                          bool sendCopy)
    {
      try
      {
        MailMessage mailMsg = new MailMessage();
        // To
        foreach (KeyValuePair<string, string> kvp in toAddressName)
        {
          string toAddress = kvp.Key;
          string displayName = kvp.Value;
          mailMsg.To.Add(new MailAddress(toAddress, displayName));
        }
        // From
        mailMsg.From = new MailAddress(fromAddress, fromName);
        if (sendCopy)
        {
          mailMsg.Bcc.Add(new MailAddress(fromAddress, fromName));
        }
        // Subject and multipart/alternative Body
        mailMsg.Subject = subject;
        string html = message;
        mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
        // Init SmtpClient and send
        SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sendgridusername", "sendgridpassword");
        smtpClient.Credentials = credentials;
        smtpClient.Send(mailMsg);
      }
      catch (Exception ex)
      {
        Error error = new Error();
        error.ReportError(ex);
      }
    }
