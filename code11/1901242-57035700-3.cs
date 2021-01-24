    private async Task copyAttachments(Attachments attachments, string folderName, string problemId)
    {
        foreach (Attachment attachment in attachments.attachments)
        {            
            await copy(attachment, folderName, problemId));
        }
    }
.....
