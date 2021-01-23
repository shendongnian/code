    public virtual MailMessage Application(ModelNameHere model)
        {
            var mailMessage = new MailMessage{Subject = "Application"};
    
            mailMessage.To.Add("debbie@gmail.com");
            //add field from your view here
            string body = model.CellPhoneNumber + Model.FirstName;
            
            ViewBag.Data = "Debbie";
            PopulateBody(mailMessage, viewName: "Application", body);
    
            return mailMessage;
        }
