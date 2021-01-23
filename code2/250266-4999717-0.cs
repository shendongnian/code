    public void SendEmailWithGZippedAttachment()
    {
    	const string attachmentText = "123,234,345,456,567\r\nabc,bcd,cde,def,efg\r\n";
    	const string filename = "myfile.csv.gz";
    	var message = new MailMessage("from@email.com", "to@email.com") { Subject = "[[EMAIL SUBJECT]]", Body = "[[EMAIL BODY]]" };
    
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
