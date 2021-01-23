          string _SMTP = WebConfigurationManager.AppSettings["SMTP"];
          Int32 _Port = Convert.ToInt16(WebConfigurationManager.AppSettings["Port"]);
          string _SMTPCredentialName = WebConfigurationManager.AppSettings["SMTPCredentialName"];
          string _SMTPCredentialPassword = WebConfigurationManager.AppSettings["SMTPCredentialPassword"];
          string _Body = null;
            System.Net.Mail.MailMessage _MailMessage = new System.Net.Mail.MailMessage();
            try
            {
                _MailMessage.To.Add(_RegUserEmail);
                _MailMessage.From = new System.Net.Mail.MailAddress(_FromEmail, _FromName);
                _MailMessage.Subject = _Subject;
                _Body = ReadTemplateRegistration(_RegisterName, _RegUserName, _RegUserEmail, _Pass, _Path);
                _MailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(_Body, "<(.|\\n)*?>", string.Empty), null, "text/plain");
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_Body, null, "text/html");
                _MailMessage.AlternateViews.Add(plainView);
                _MailMessage.AlternateViews.Add(htmlView);
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(_SMTP, _Port);
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(_SMTPCredentialName, _SMTPCredentialPassword);
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = basicAuthenticationInfo;
                _MailMessage.IsBodyHtml = true;
                mailClient.Send(_MailMessage);
            }
            catch (Exception ex)
            {
                return "ERROR" + ex.ToString();
            }
