c+
foreach (MailItem email in Globals.ThisAddIn.Application.ActiveExplorer().Selection)
{
    string email_id = ArchiveEmail(email);
    if (chkBoxSyncEmail.Checked)
    {    
        // collecting attachements
        array attachements;                                    
        foreach (Attachment atch in email.Attachments)
        {            
            if(AttachmentsBeingSent.Contains(atch.FileName))
            {
                string filePath = Path.Combine(@"", (email_id + atch.FileName)); //We add the unique email_id to the beginning of the filename, it is always 13 chars long so we can pull the unique id off later with ease.
                atch.SaveAsFile(filePath); //Save as file
                attachements[] = filePath;
            }
        }
        try
        {
            // if there are any attachements, send the mail
            if(sizeof(attachements)
            {
                //Sending attachments.
                WebClient wc = new WebClient();
                await wc.UploadFileTaskAsync(new Uri("https://xxxx.com/xxxx/xxxx/xxxx/upload_attachment.php"), "POST", attachements);                             
                
                ...
            }                        
        }                      
    }
}
I removed a few lines with some logic which was prepared to send only one file. If you send multiple files at once, things are working different and you can't handle a feedback for every single file, at least not in the kind like you coded.
