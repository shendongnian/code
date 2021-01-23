    ResumeUpload.PostedFile.SaveAs(Path.Combine(Server.MapPath("/"), "resumes", ResumeUpload.FileName));
    
    var emailAttachement = new Attachment(Path.Combine(Server.MapPath("/"), "resumes", ResumeUpload.FileName));
    message.Attachments.Add(emailAttachement);
    
    using (var client = new SmtpClient())
    {
    	client.Send(message);
    }
