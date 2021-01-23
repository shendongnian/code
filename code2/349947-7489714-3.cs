    public static void SendMessage(string smtpServer, string mailFrom, string mailFromDisplayName, string[] mailTo, string[] mailCc, string subject, string body)
    {
        try
        {
            using (SmtpClient client = new SmtpClient(smtpServer))
            {
                string to = mailTo != null ? string.Join(",", mailTo) : null;
                string cc = mailCc != null ? string.Join(",", mailCc) : null;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(mailFrom, mailFromDisplayName);
                mail.To.Add(to);
                if (cc != null)
                {
                    mail.CC.Add(cc);
                }
                mail.Subject = subject;
                mail.Body = body.Replace(Environment.NewLine, "<BR>");
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
        }
        catch (Exception ex)
        {
            // exception handling
        }
    }
