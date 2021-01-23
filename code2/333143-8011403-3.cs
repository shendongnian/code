    var exchanges = new [] {
          new DataExchange<DataObject, Attachment>( new DataToAttachmentConverter(), new MailSender()),
          new DataExchange<DataObject, XmlDocument>( new DataToXmlConverter(), new FtpPublisher())
    };
    
    foreach(var ex in exchanges)
        ex.Send(dataObject); //send as an attachent and put to ftp site.
