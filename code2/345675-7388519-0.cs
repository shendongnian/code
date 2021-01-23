	try
	{
		// To
		MailMessage mailMsg = new MailMessage();
		mailMsg.To.Add(to_Address);
		// From
		MailAddress mailAddress = new MailAddress(from_address);
		mailMsg.From = mailAddress;
		// Subject and Body
		mailMsg.Subject = subject;
		mailMsg.Body    = body;
		// Init SmtpClient and send
		SmtpClient smtpClient = new SmtpClient(smtp_server, port);
		// System.Net.NetworkCredential credentials =
        //    new System.Net.NetworkCredential(smtp_user, smtp_pwd);
		// smtpClient.Credentials = credentials;
		smtpClient.Send(mailMsg);
	}
	catch (Exception ex)
	{
		Console.WriteLine( ex.Message );
	}
