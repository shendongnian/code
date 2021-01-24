     var selection = explorer.Selection;
    
                if (selection.Count == 1)
                {
                    object selectedItem = selection[1];
    
                    var mailItem = selectedItem as Outlook.MailItem;
                    if (mailItem == null) return;
    
    
                  foreach (Outlook.Attachment attachment in mailItem.Attachments)
                     {
    
                      bool validAttachment = isAnAttachment(attachment);
                      }       
                }
   
     private bool isAnAttachment(Outlook.Attachment attachment)
                    {
                        bool isValid = false;
                        var attachmentType = attachment.FileName.Substring(attachment.FileName.LastIndexOf('.'));
                        if (attachmentType != null && attachmentType.Trim().Length > 1 && _fileTypeFilter.Contains(attachmentType.Substring(1).ToLower()))
                        {
                            Outlook.PropertyAccessor prop = attachment.PropertyAccessor;
            
                            var flags = prop.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x37140003");
            
                            var asize = attachment.Size;
                            // As per present understanding - If rtF mail attachment comes here - and the embeded image is treated as attachmet
                            if ((attachmentType.Substring(1).ToLower() == "pdf") || (asize > 0 && flags != 4 && (int)attachment.Type != 6))
                            {
                                isValid = true;
                            }
                        }
                        return isValid;
                    }
