    private async Task<System.Net.HttpStatusCode> Execute(String EmailId, String Message)
            {
                var apiKey = "abcdefghijklmnopqrstuvwxyz1234567890";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("myemail@gmail.com", "Sender");
                var subject = "Testing Email";
                var to = new EmailAddress(EmailId, "Reciever");
                var plainTextContent = "You have recieved this message from me";
                var htmlContent = Message + "<br><i>-Message sent by me</i>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
                return response.StatusCode;
    
            }
    private async Task GetStatusCodeExample(String EmailId, String Message)
    {
        var statusCode = await Execute(EmailId, Message);
    }
