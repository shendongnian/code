    // ouside the action I've defined the response
    private class gapi {public bool success{get;set;}}
	
    public bool SendMail(string firstname, string lastname, string email, string message, string grecaptcha)
    {
		SmtpClient smtp = new SmtpClient("smtp.1and1.com");
		MailMessage mail = new MailMessage();
		mail.From = new MailAddress(email);
		mail.To.Add("mail@domain.com");
		mail.Subject = firstname + " " + lastname;
		mail.Body = message;
		try
		{
			using (var client = new WebClient())
			{
				var values = new NameValueCollection();
				values["secret"] = "6LcEnQYTAAAAAOWzB44-m0Ug9j4yem9XE4ARERUR";
				values["response"] = grecaptcha;
				values["remoteip"] = Request.UserHostAddress;
				var response = client.UploadValues("https://www.google.com/recaptcha/api/siteverify","POST", values);
				bool result = Newtonsoft.Json.JsonConvert.DeserializeObject<gapi>((Encoding.Default.GetString(response) as string)).success;
				if(!result) return "Something is wrong)";
			}
			//... verify that the other fields are ok and send your mail :)
			smtp.Send(mail);
		}
		catch (Exception e) { return "Something is wrong)"; }
		return "Okey :)";
	}
