    public Boolean SendRawEmail(String from, String to, String cc, String Subject, String text, String html, String replyTo, string attachPath)
        {
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(text, Encoding.UTF8, "text/plain");
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, "text/html");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            List<String> toAddresses = to.Replace(", ", ",").Split(',').ToList();
            foreach (String toAddress in toAddresses)
            {
                mailMessage.To.Add(new MailAddress(toAddress));
            }
            List<String> ccAddresses = cc.Replace(", ", ",").Split(',').Where(y => y != "").ToList();
            foreach (String ccAddress in ccAddresses)
            {
                mailMessage.CC.Add(new MailAddress(ccAddress));
            }
            mailMessage.Subject = Subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            if (replyTo != null)
            {
                mailMessage.ReplyToList.Add(new MailAddress(replyTo));
            }
            if (text != null)
            {
                mailMessage.AlternateViews.Add(plainView);
            }
            if (html != null)
            {
                mailMessage.AlternateViews.Add(htmlView);
            }
            if (attachPath.Trim() != "")
            {
                if (System.IO.File.Exists(attachPath))
                {
                    System.Net.Mail.Attachment objAttach = new System.Net.Mail.Attachment(attachPath);
                    objAttach.ContentType = new ContentType("application/octet-stream"); 
                    System.Net.Mime.ContentDisposition disposition = objAttach.ContentDisposition;
                    disposition.DispositionType = "attachment";
                    disposition.CreationDate = System.IO.File.GetCreationTime(attachPath);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachPath);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(attachPath);
                    mailMessage.Attachments.Add(objAttach);
                }
            }
            RawMessage rawMessage = new RawMessage();
            using (MemoryStream memoryStream = ConvertMailMessageToMemoryStream(mailMessage))
            {
                rawMessage.WithData(memoryStream);
            }
            SendRawEmailRequest request = new SendRawEmailRequest();
            request.WithRawMessage(rawMessage);
            request.WithDestinations(toAddresses);
            request.WithSource(from);
            AmazonSimpleEmailService ses = AWSClientFactory.CreateAmazonSimpleEmailServiceClient(ConfigurationManager.AppSettings.Get("AccessKeyId"), ConfigurationManager.AppSettings.Get("SecretKeyId"));
            try
            {
                SendRawEmailResponse response = ses.SendRawEmail(request);
                SendRawEmailResult result = response.SendRawEmailResult;
                return true;
            }
            catch (AmazonSimpleEmailServiceException ex)
            {
                return false;
            }
        }
        public static MemoryStream ConvertMailMessageToMemoryStream(MailMessage message)
        {
            Assembly assembly = typeof(SmtpClient).Assembly;
            Type mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
            MemoryStream fileStream = new MemoryStream();
            ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);
            object mailWriter = mailWriterContructor.Invoke(new object[] { fileStream });
            MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);
            sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { mailWriter, true }, null);
            MethodInfo closeMethod = mailWriter.GetType().GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);
            closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null);
            return fileStream;
        }
