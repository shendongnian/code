      ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);
      service.Credentials = new NetworkCredential("login", "password");
    
      service.Url = new Uri("https://mail.Yourservername.com/EWS/Exchange.asmx");
    
      ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    
      FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10));
    
      if (findResults != null && findResults.Items != null && findResults.Items.Count > 0)
          foreach (EmailMessage item in findResults)
           {
             EmailMessage message = EmailMessage.Bind(service, item.Id, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments, ItemSchema.HasAttachments));
               foreach (Attachment attachment in message.Attachment
                 {
                   if (attachment is FileAttachment)
                      {
                        FileAttachment fileAttachment = attachment as FileAttachment;      
                        fileAttachment.Load(@"Folder\file.name");
                       }
                 }
            }
 
