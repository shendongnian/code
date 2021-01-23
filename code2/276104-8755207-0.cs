            string contentID = "Image1.gif".Replace(".", "") + "@test";
            // create the INLINE attachment
            string attachmentPath = Server.MapPath("Images/Image1.gif");
            inline = new Attachment(attachmentPath);
            inline.ContentDisposition.Inline = true;
            inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            inline.ContentId = contentID;
            inline.ContentType.MediaType = "image/gif";
            inline.ContentType.Name = Path.GetFileName(attachmentPath);
            //then add in the message body
            //stringbuilder to construct the message
            sb = new StringBuilder();
            sb.Append("<div style=\"font-family:Arial\"> Hello World!<br /><br /><img src=\"@@IMAGE@@\" alt=\"\" Width=\"250px\" Height=\"250px\"><br /><br /></div>");
            //creating the message with from and to and the smpt server connections
            mail = new MailMessage("SendersEmail@Address.com", "RecieversEmail@Address.com");
            SmtpServer = new SmtpClient("smtp.gmail.com"); //Add SMTP settings into the Web.Config --> ConfigurationManager.AppSettings["MyCustomId"]
            mail.Subject = "Testing Emails";
            mail.IsBodyHtml = true;
            mail.Body = sb.ToString();
            mail.Attachments.Add(inline);
            // replace the tag with the correct content ID
            mail.Body = mail.Body.Replace("@@IMAGE@@", "cid:" + contentID);
