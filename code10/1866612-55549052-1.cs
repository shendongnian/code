      public void SendMail(string to, string cc, string subject, AlternateView body, string path)
        {
            MailMessage message = new MailMessage(AppSettings.Default.From, to);
            if (!String.IsNullOrEmpty(path)) message.Attachments.Add(new Attachment(path));
            if (!String.IsNullOrEmpty(cc)) message.CC.Add(cc);
            if (body != null)
            {
                message.AlternateViews.Add(body);
                message.IsBodyHtml = true;
            }
            message.Body = subject;
            message.Subject = subject;
            Thread bgThread = new Thread(new ParameterizedThreadStart(SendEmailInBackgroud));
            bgThread.IsBackground = true;
            bgThread.Start(message);
        }
