    public static void GetAttachmentsFromEmail(ExchangeService service, ItemId itemId)
        {
            // Bind to an existing message item and retrieve the attachments collection.
            // This method results in an GetItem call to EWS.
            EmailMessage message = EmailMessage.Bind(service, itemId, new PropertySet(ItemSchema.Attachments));
 
            // Iterate through the attachments collection and load each attachment.
            foreach (Attachment attachment in message.Attachments)
            {
                if (attachment is FileAttachment)
                {
                    FileAttachment fileAttachment = attachment as FileAttachment;
 
                    // Load the attachment into a file.
                    // This call results in a GetAttachment call to EWS.
                    fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);
 
                    Console.WriteLine("File attachment name: " + fileAttachment.Name);
                }
                else // Attachment is an item attachment.
                {
                    ItemAttachment itemAttachment = attachment as ItemAttachment;
 
                    // Load attachment into memory and write out the subject.
                    // This does not save the file like it does with a file attachment.
                    // This call results in a GetAttachment call to EWS.
                    itemAttachment.Load();
 
                    Console.WriteLine("Item attachment name: " + itemAttachment.Name);
                }
            }
        }
