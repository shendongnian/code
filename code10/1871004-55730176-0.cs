    var client = new SendGridClient(apiKey);
	var msg = new SendGridMessage()
    {
        From = new EmailAddress(senderMailID, senderName),
        Subject = "ABCD",
    };
	var bytes = File.ReadAllBytes("~/Templates/output.pdf");
	var file = Convert.ToBase64String(bytes);
	msg.AddAttachment("ABC.pdf", file);
	var response = await client.SendEmailAsync(msg);
