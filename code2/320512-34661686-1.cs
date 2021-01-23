    using Amazon.SimpleEmail;
    using Amazon.SimpleEmail.Model;
    using Amazon;
    using Amazon.Runtime;
    using MimeKit;
    private static BodyBuilder GetMessageBody()
    {
        var body = new BodyBuilder()
        {
            HtmlBody = @"<p>Amazon SES Test body</p>",
            TextBody = "Amazon SES Test body",
        };
        body.Attachments.Add(@"c:\attachment.txt");
        return body;
    }
    private static MimeMessage GetMessage()
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Foo Bar", "foo@bar.com"));
        message.To.Add(new MailboxAddress(string.Empty, "foobar@example.com"));
        message.Subject = "Amazon SES Test";
        message.Body = GetMessageBody().ToMessageBody();
        return message;
    }
    private static MemoryStream GetMessageStream()
    {
        var stream = new MemoryStream();
        GetMessage().WriteTo(stream);
        return stream;
    }
    private void SendEmails()
    {
        var credentals = new BasicAWSCredentials("<aws-access-key>", "<aws-secret-key>");
        using (var client = new AmazonSimpleEmailServiceClient(credentals, RegionEndpoint.EUWest1))
        {
            var sendRequest = new SendRawEmailRequest { RawMessage = new RawMessage(GetMessageStream()) };
            try
            {
                var response = client.SendRawEmail(sendRequest);
                Console.WriteLine("The email was sent successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The email was not sent.");
                Console.WriteLine("Error message: " + e.Message);
            }
        }
    }
