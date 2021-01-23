	MailMessage mail = new MailMessage();
	//Create a MemoryStream from a file for this test
	MemoryStream ms = new MemoryStream(File.ReadAllBytes(@"C:\temp\test.gif"));
	
	mail.Attachments.Add(new System.Net.Mail.Attachment(ms, "test.gif"));
	if (mail.Attachments[0].ContentStream == ms) Console.WriteLine("Streams are referencing the same resource");
	Console.WriteLine("Stream length: " + mail.Attachments[0].ContentStream.Length);
	
	//Dispose the mail as you should after sending the email
	mail.Dispose();
	//--Or you can dispose the attachment itself
	//mm.Attachments[0].Dispose();
	
	Console.WriteLine("This will throw a 'Cannot access a closed Stream.' exception: " + ms.Length);
