    private void Send(string body, bool isHtml, string subject, string recipientAddress, string recipientName, string fromAddress)
    {
        using (var message = new MailMessage(new MailAddress(fromAddress),
                                        new MailAddress(recipientAddress, recipientName)))
        {
            message.Subject = subject;
            var alternateView = AlternateView.CreateAlternateViewFromString(body, message.BodyEncoding,
                                                                            isHtml ? "text/html" : "text/plain");
            alternateView.TransferEncoding = TransferEncoding.QuotedPrintable;
            message.AlternateViews.Add(alternateView);
    
            var client = new SmtpClient();
    
            client.Send(message);
        }
    }
