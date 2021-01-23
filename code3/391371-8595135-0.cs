    public virtual MailMessage Welcome(string email, string name)
    {     
       var mailMessage = new MailMessage{Subject = "Welcome to MvcMailer"};
       mailMessage.To.Add(email);
       ViewBag.Name = name;
       PopulateBody(mailMessage, viewName: "Welcome");
       return mailMessage; 
    } 
