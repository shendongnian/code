    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using MailMessage=System.Net.Mail.MailMessage;
    class CTEmailSender
    {
        string MailSmtpHost { get; set; }
        int MailSmtpPort { get; set; }
        string MailSmtpUsername { get; set; }
        string MailSmtpPassword { get; set; }
        string MailFrom { get; set; }
        public bool SendEmail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage(MailFrom, to, subject, body);
            var alternameView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));
            mail.AlternateViews.Add(alternameView);
            var smtpClient = new SmtpClient(MailSmtpHost, MailSmtpPort);
            smtpClient.Credentials = new NetworkCredential(MailSmtpUsername, MailSmtpPassword);
            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                //Log error here
                return false;
            }
            return true;
        }
    }
