    foreach (Attachment att in message.Attachments)
    {
                //Load the attachment 
                att.Load();
                //turnt the message.Attachments to a Item(Object)
                ItemAttachment ItemAtt = att as ItemAttachment;
                //Create a ItemSchema of Attachments in itemAtt  
                ItemAtt.Load(new PropertySet(ItemSchema.Attachments));
                foreach (Attachment scannedAttachment in ItemAtt.Item.Attachments)
                {
                    scannedAttachment.Load();
                    //Loads all Item Attachments as File Attachments
                    FileAttachment fileAttachment = scannedAttachment as FileAttachment;
                    if (Regex.IsMatch(fileAttachment.Name, ".pdf|.PDF|.Pdf"))
                    {
                        
                    }
                }
    }
