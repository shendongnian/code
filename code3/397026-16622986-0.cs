        Array arrayParameters = new object[2];
        arrayParameters = (Array)parameters;
        string Email = (string)arrayParameters.GetValue(0);
        string subjectEmail = (string)arrayParameters.GetValue(1);
        if (Email != "Email@email.com")
        {
            OnlineSearch OnlineResult = new OnlineSearch();
            try
            {
                StringBuilder str = new StringBuilder();
                MailMessage mailMessage = new MailMessage();
             
                //here we set the address
                mailMessage.From = fromAddress;
                mailMessage.To.Add(Email);//here you can add multiple emailid
                mailMessage.Subject = "";
                //here we set add bcc address
                //mailMessage.Bcc.Add(new MailAddress("bcc@site.com"));
                str.Append("<html>");
                str.Append("<body>");
                str.Append("<table width=720 border=0 align=left cellpadding=0 cellspacing=5>");
               
                str.Append("</table>");
                str.Append("</body>");
                str.Append("</html>");
                //To determine email body is html or not
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = str.ToString();
                //file attachment for this e-mail message.
                Attachment attach = new Attachment();
                mailMessage.Attachments.Add(attach);
                mailClient.Send(mailMessage);
            }
          
    }
