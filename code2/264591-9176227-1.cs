    static void Main(string[] args)
    {
        string smtpServer = String.Empty;
        string userName = String.Empty;
        string password = String.Empty;
        string attachmentFilePath = String.Empty;
        string displayName = String.Empty;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpServer);
        client.Credentials = new System.Net.NetworkCredential(userName, password);
        var msg = new System.Net.Mail.MailMessage(fromAddress, toAddress, "Subject", "Body");
        System.Net.Mail.Attachment attachment =
             AttachmentHelper.CreateAttachment(attachmentFilePath, displayName, TransferEncoding.Base64);
        msg.Attachments.Add(attachment);
        client.Send(msg);
    }
