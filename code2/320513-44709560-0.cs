    using Amazon;
    using Amazon.SimpleEmail;
    using Amazon.SimpleEmail.Model;
    using MimeKit;
    using System.IO;
    namespace SendEmailWithAttachments
    {
     class Program
     {
        static void Main(string[] args)
        {
            //Remember to enter your (AWSAccessKeyID, AWSSecretAccessKey) if not using and IAM User with credentials assigned to your instance and your RegionEndpoint
            using (var client = new AmazonSimpleEmailServiceClient("YourAWSAccessKeyID", "YourAWSSecretAccessKey", RegionEndpoint.USEast1))
            using (var messageStream = new MemoryStream())
            {
                var message = new MimeMessage();
                var builder = new BodyBuilder() { TextBody = "Hello World" };
                message.From.Add(new MailboxAddress("FROMADDRESS@TEST.COM"));
                message.To.Add(new MailboxAddress("TOADDRESS@TEST.COM"));
                message.Subject = "Hello World";
                //I'm using the stream method, but you don't have to.
                using (FileStream stream = File.Open(@"Attachment1.pdf", FileMode.Open)) builder.Attachments.Add("Attachment1.pdf", stream);
                using (FileStream stream = File.Open(@"Attachment2.pdf", FileMode.Open)) builder.Attachments.Add("Attachment2.pdf", stream);
                message.Body = builder.ToMessageBody();
                message.WriteTo(messageStream);
                var request = new SendRawEmailRequest()
                {
                    RawMessage = new RawMessage() { Data = messageStream }
                };
                client.SendRawEmail(request);
            }
        }
      }
    }
