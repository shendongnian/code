    MailItem MailItemSelected =  this.OutlookItem;   
    foreach (Attachment a in MailItemSelected.Attachments)
    {
       bool addAttachment = false;
       try
       {
          string schemaPR_ATTACH_FLAGS = "http://schemas.microsoft.com/mapi/proptag/0x37140003"; 
          a.PropertyAccessor.GetProperty(schemaPR_ATTACH_FLAGS);
       }
       catch
       {
          addAttachment = true;
       }
    
       if (addAttachment && (a.Size != 0))
          a.SaveAsFile(path + a.FileName);
    }
