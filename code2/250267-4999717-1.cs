    public void SendEmailWithGZippedAttachment(string fromAddress, string toAddress, string subject, string body, string attachmentText)
    {
		const string filename = "myfile.csv.gz";
		var message = new MailMessage(fromAddress, toAddress, subject, body);    	const string filename = "myfile.csv.gz";
    
    	//Compress and save to temp file
    	var tempFilename = Path.GetTempFileName();
    	using(var input = new MemoryStream(Encoding.UTF8.GetBytes(attachmentText)))
    	{
    		using(var output = File.Create(tempFilename))
    		{
    			using (var gzipStream = new GZipStream(output, CompressionMode.Compress))
 			   {
 			       input.CopyTo(gzipStream);
 			   }
 		    }
 	    }
    
 		//Attach and send email
 		//Must execute send while fs is open
 		using(var fs = File.OpenRead(tempFilename))
 		{
 			message.Attachments.Add(new Attachment(fs, filename, "application/x-gzip"));
 			var smtp = new SmtpClient("mail.myemailserver.com") { Credentials = new NetworkCredential("username", "password") };
 			smtp.Send(message);
 		}
    
 		//Clean up
 		File.Delete(tempFilename);
    }
