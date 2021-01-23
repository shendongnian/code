        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            byte[] data = new byte[1024];
            MemoryStream stream = new MemoryStream(data);
            Attachment attach = new Attachment(stream, "Attachment file name");
            mail.Attachments.Add(attach);
            new SmtpClient().Send(mail);
        }
