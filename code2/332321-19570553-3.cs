    [TestMethod]
    public void ReadImap()
    {
    	var mailRepository = new MailRepository(
    							"imap.gmail.com",
    							993,
    							true,
    							"yourEmailAddress@gmail.com",
    							"yourPassword"
    						);
    
    	var emailList = mailRepository.GetAllMails("inbox");
    
    	foreach (Message email in emailList)
    	{
    		Console.WriteLine("<p>{0}: {1}</p><p>{2}</p>", email.From, email.Subject, email.BodyHtml.Text);
    		if (email.Attachments.Count > 0)
    		{
    			foreach (MimePart attachment in email.Attachments)
    			{
    				Console.WriteLine("<p>Attachment: {0} {1}</p>", attachment.ContentName, attachment.ContentType.MimeType);
    			}
    		}
    	}
    }
