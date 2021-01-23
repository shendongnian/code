    public void SendEmailWithGZippedAttachment(string fromAddress, string toAddress, string subject, string body, string attachmentText)
    {
	    	const string filename = "myfile.csv.gz";
			var message = new MailMessage(fromAddress, toAddress, subject, body);
			
			//Compress and save buffer
			var output = new MemoryStream();
			using (var gzipStream = new GZipStream(output, CompressionMode.Compress))
			{
				using(var input = new MemoryStream(Encoding.UTF8.GetBytes(attachmentText)))
				{
					input.CopyTo(gzipStream);
				}
			}
            //output.ToArray is still accessible even though output is closed
			byte[] buffer = output.ToArray(); 
			//Attach and send email
			using(var stream = new MemoryStream(buffer))
			{
				message.Attachments.Add(new Attachment(stream, filename, "application/x-gzip"));
				var smtp = new SmtpClient("mail.myemailserver.com") {Credentials = new NetworkCredential("username", "password")};
				smtp.Send(message);
			}
    }
