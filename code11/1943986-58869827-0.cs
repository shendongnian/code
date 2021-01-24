foreach (var attachment in email.Attachments)
{
    if (attachment is FileAttachment)
    {
        FileAttachment fileAttachment = attachment as FileAttachment;
        fileAttachment.Load();
        responseMessageWithAttachment.Attachments.AddFileAttachment(attachment.Name, fileAttachment.Content);
    }
}
responseMessageWithAttachment.SendAndSaveCopy();
