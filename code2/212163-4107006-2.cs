    public string DecodeQuotedPrintable(string value)
    {
            Attachment attachment = Attachment.CreateAttachmentFromString("", value);
            return attachment.Name;
    }
