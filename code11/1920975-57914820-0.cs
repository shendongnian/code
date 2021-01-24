lang-cs
if (message.HasAttachments == true)
{
    // Get attachment information.
    var attachmentsInfo = await graphClient.Me.Messages[message.Id]
                                                           .Attachments
                                                           .Request()
                                                           .Select("id")
                                                           .GetAsync();
    foreach (var attachmentFileInfo in attachmentsInfo)
    {
        if (attachmentFileInfo.ODataType.ToLower() == ("#microsoft.graph.fileAttachment").ToLower())
        {
            // Get the attachment bytes
            var attachment = await graphClient.Me.Messages[message.Id]
                                                          .Attachments[attachmentFileInfo.Id]
                                                          .Request()
                                                          .GetAsync();
            var fileStream = new MemoryStream(attachment.ContentBytes);
            email.Attachments.Add(fileStream, attachment.Name, -1, attachment.IsInline, attachmment.Id);
        }
        else if (attachment.ODataType.ToLower() == ("#microsoft.graph.itemAttachment").ToLower())
        {
            email.Attachments.Add(attachment.Name, -1, attachment.IsInline, attachment.Id);
        }
    }
}
