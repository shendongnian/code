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
                    MemoryStream copy = new MemoryStream( capacity: file.ContentLength );
                    file.InputStream.CopyTo( copy );
                    // Rewind the stream, this is important! (You cannot rewind ASP.NET's file.InputStream, hence why we use a MemoryStream copy).
                    copy.Seek( 0, SeekOrigin.Begin );
                    DoSomethingWithFileStream( copy );
                    // Rewind the stream again, this is important!
                    copy.Seek( 0, SeekOrigin.Begin );
                    Attachment att = new Attachment( copy, name: file.FileName );
                    emailMessage.Attachments.Add( att );
                } 
            }
        }
        mailClient.Send( emailMessage );
    }
