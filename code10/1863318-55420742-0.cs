    var stringInsideTheFile = "Hello, I'm a test only";
	var filename = string.Format("%TEMP%\{0}", DateTime.UtcNow.Ticks);
	var test = File.WriteAllText(filename, stringInsideTheFile);
	MailMessage message = new MailMessage();
	message.Attachments.Add(new Attachment(filename));
	File.Delete(filename);
