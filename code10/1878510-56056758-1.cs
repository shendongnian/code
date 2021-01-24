            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress ("Joey", "joey@friends.com"));
            message.To.Add (new MailboxAddress ("Alice", "alice@wonderland.com"));
            message.Subject = "How you doin?";
            var builder = new BodyBuilder ();
            // Set the plain-text version of the message text
            builder.TextBody = @"Hey Alice,
    ....
    -- Joey
    ";
            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.
            var image = builder.LinkedResources.Add (@"C:\Users\Joey\Documents\Selfies\selfie.jpg");
            image.ContentId = MimeUtils.GenerateMessageId ();
            // Set the html version of the message text
            builder.HtmlBody = string.Format (@"<p>Hey Alice,<br>
    ....
    <p>-- Joey<br>
    <center><img src=""cid:{0}""></center>", image.ContentId);
            // We may also want to attach a calendar event for Monica's party...
            builder.Attachments.Add (@"C:\Users\Joey\Documents\party.ics");
            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody ();
