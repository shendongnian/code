    HttpFileCollectionBase addedFiles = ...
    using( SmtpClient  mailClient = new SmtpClient( smtpServer, Convert.ToInt16( smtpPort ) ) )
    using( MailMessage emailMessage = new MailMessage( fromAddress, toAddress, subject, message ) )
    {
        if( addedFiles?.Count > 0 )
        {
            foreach( HttpPostedFileBase file in addedFiles )
            {
                Boolean isOK = ( file.FileName.EndsWith( ".pdf", StringComparison.OrdinalIgnoreCase ) || file.FileName.EndsWith( ".doc", StringComparison.OrdinalIgnoreCase ) ) && file.ContentLength > 0 && file.ContentLength < 10485760;
                if( isOK )
                {
                    Attachment att = new Attachment( file.InputStream, name: file.FileName );
                    emailMessage.Attachments.Add( att );
                } 
            }
        }
        mailClient.Send( emailMessage );
    }
