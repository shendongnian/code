        public MailMessage createMailMessage(string toAddress, string fromAddress, string subject, string template)
        {
        // Validate arguments here...
    
        // If your template contains any of the following {tokens}
        // they will be replaced with the values you set here.
        var replacementDictionary = new ListDictionary
               {
                   // Replace with your own list of values
                   { "{first}", "Pull from db or config" },
                   { "{last}", "Pull from db or config" }
               };
        
        // Create a text view and HTML view (both will be in the same email)
        // This snippet assumes you are using ASP.NET (works w/MVC)
        //    if not, replace HostingEnvironment.MapPath with your own path.
        var mailDefinition = new MailDefinition { BodyFileName = HostingEnvironment.MapPath(template + ".txt"), IsBodyHtml = false };
        var htmlMailDefinition = new MailDefinition { BodyFileName = HostingEnvironment.MapPath(template + ".htm"), IsBodyHtml = true };
            
        MailMessage htmlMessage = htmlMailDefinition.CreateMailMessage(email, replacementDictionary, new Control());
        MailMessage textMessage = mailDefinition.CreateMailMessage(email, replacementDictionary, new Control());
            
        AlternateView plainView = AlternateView.CreateAlternateViewFromString(textMessage.Body, null, "text/plain");
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlMessage.Body, null, "text/html");
            
        var message = new MailMessage { From = new MailAddress(from) };
            
        message.To.Add(new MailAddress(toAddress));
        message.Subject = subject;
            
        message.AlternateViews.Add(plainView);
        message.AlternateViews.Add(htmlView);
            
        return message;
        }
