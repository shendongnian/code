    private bool SendMail(String From, String To, String Subject, String Html)
        {
            try
            {
                System.Net.Mail.SmtpClient SMTPSender = null;
                if (From.Split('@')[0] == "noreply")
                {
                    System.Net.Configuration.SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("mailSettings2/noreply");
                    SMTPSender = new System.Net.Mail.SmtpClient(smtpSection.Network.Host, smtpSection.Network.Port);
                    SMTPSender.Credentials = new System.Net.NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
                    Message.From = new System.Net.Mail.MailAddress(From);
                    Message.To.Add(To);
                    Message.Subject = Subject;
                    Message.Bcc.Add(Recipient);
                    Message.IsBodyHtml = true;
                    Message.Body = Html;
                    Message.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                    Message.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                    SMTPSender.Send(Message);
                }
                else
                {
                    SMTPSender = new System.Net.Mail.SmtpClient();
                    System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
                    Message.From = new System.Net.Mail.MailAddress(From);
                    SMTPSender.EnableSsl = SMTPSender.Port == <Port1> || SMTPSender.Port == <Port2>;
                    Message.To.Add(To);
                    Message.Subject = Subject;
                    Message.Bcc.Add(Recipient);
                    Message.IsBodyHtml = true;
                    Message.Body = Html;
                    Message.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                    Message.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                    SMTPSender.Send(Message);
                }
            }
            catch (Exception Ex)
            {
                Logger.Error(Ex.Message, Ex.GetBaseException());
                return false;
            }
            return true;
        }
