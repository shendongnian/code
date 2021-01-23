    //Get the files submitted form object
                HttpFileCollection Files = HttpContext.Current.Request.Files;
    
                //Get the first file. There could be multiple if muti upload is supported
                string fileName = Files[0].FileName;
    
                //Some validation
                if(Files.Count == 1 && Files[0].ContentLength > 1 && !string.IsNullOrEmpty(fileName))
                { 
                    //Get the input stream and file name and create the email attachment
                    Attachment myAttachment = new Attachment(Files[0].InputStream, fileName);
    
                    //Send email
                    MailMessage msg = new MailMessage(new MailAddress("emailaddress@emailaddress.com", "name"), new MailAddress("emailaddress@emailaddress.com", "name"));
                    msg.Subject = "Test";
                    msg.Body = "Test";
                    msg.IsBodyHtml = true;
                    msg.Attachments.Add(myAttachment);
    
                    SmtpClient client = new SmtpClient("smtp");
                    client.Send(msg);
                }
