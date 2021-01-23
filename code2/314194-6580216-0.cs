public void SendEmailWithPicture(string email, byte[] image)
{
    string filename = "AttachmentName.jpg";
    LinkedResource linkedResource = new LinkedResource(new MemoryStream(image), "image/jpg");
    linkedResource.ContentId = filename;
    linkedResource.ContentType.Name = filename;
    this.Send(
        EmailTemplates.sendpicture,
        this.Subjects.SendPicture,
        new List<string>() { email },
        this.ReplyTo,
        tagValues: new Dictionary<string, string>() { { "ImageAttachmentName", "cid:" + filename } },
        htmlLinkedResources: new List<LinkedResource>() { linkedResource }
        );
}
private void Send(EmailTemplates template, string subject, List<string> to, string replyTo,
    Dictionary<string, string> tagValues = null, List<Attachment> attachments = null, List<LinkedResource> htmlLinkedResources = null)
{
    try
    {
        MailMessage mailMessage = new MailMessage();
        // Set up the email header.
        to.ForEach(t => mailMessage.To.Add(new MailAddress(t)));
        mailMessage.ReplyToList.Add(new MailAddress(replyTo));
        mailMessage.Subject = subject;
                
        string fullTemplatePath = Path.Combine(this.TemplatePath, EMAIL_TEMPLATE_PATH);
        // Load the email bodies
        var htmlBody = File.ReadAllText(Path.Combine(fullTemplatePath, Path.ChangeExtension(template.ToString(), "html")));
        var textBody = File.ReadAllText(Path.Combine(fullTemplatePath, Path.ChangeExtension(template.ToString(), "txt")));
        // Replace the tags in the emails
        if (tagValues != null)
        {
            foreach (var entry in tagValues)
            {
                string tag = "{{" + entry.Key + "}}";
                htmlBody = htmlBody.Replace(tag, entry.Value);
                textBody = textBody.Replace(tag, entry.Value);
            }
        }
        // Create plain text alternative view
        string baseTxtTemplate = File.ReadAllText(Path.Combine(fullTemplatePath, TXT_BASE_TEMPLATE));
        textBody = baseTxtTemplate.Replace(TAG_CONTENT, textBody);
        AlternateView textView = AlternateView.CreateAlternateViewFromString(textBody, new System.Net.Mime.ContentType("text/plain"));
        // Create html alternative view
        string baseHtmlTemplate = File.ReadAllText(Path.Combine(fullTemplatePath, HTML_BASE_TEMPLATE));
        htmlBody = baseHtmlTemplate.Replace(TAG_CONTENT, htmlBody);
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, new System.Net.Mime.ContentType("text/html"));
        // Add any html linked resources
        if (htmlLinkedResources != null)
        {
            htmlLinkedResources.ForEach(lr => htmlView.LinkedResources.Add(lr));
            htmlLinkedResources.ForEach(lr => textView.LinkedResources.Add(lr));
        }
        // Add the two views (gmail will always display plain text version if its added last)
        mailMessage.AlternateViews.Add(textView);
        mailMessage.AlternateViews.Add(htmlView);
        // Add any attachments
        if (attachments != null)
        {
            attachments.ForEach(a => mailMessage.Attachments.Add(a));
        }
        // Send the email.
        SmtpClient smtp = new SmtpClient();
        smtp.Send(mailMessage);
    }
    catch (Exception ex)
    {
        throw new Exception(String.Format("Error sending email (to:{0}, replyto:{1})", String.Join(",", to), replyTo), ex);
    }
}
