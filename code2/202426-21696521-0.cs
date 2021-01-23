    /// <summary>
    /// Method to get all attachments that are NOT inline attachments (like images and stuff).
    /// </summary>
    /// <param name="mailItem">
    /// The mail item.
    /// </param>
    /// <returns>
    /// The <see cref="List"/>.
    /// </returns>
    public static List<Outlook.Attachment> GetMailAttachments(Outlook.MailItem mailItem) {
        const string PR_ATTACH_METHOD = "http://schemas.microsoft.com/mapi/proptag/0x37050003";
        const string PR_ATTACH_FLAGS = "http://schemas.microsoft.com/mapi/proptag/0x37140003";
    
        var attachments = new List<Outlook.Attachment>();
    
        // if this is a plain text email, every attachment is a non-inline attachment
        if (mailItem.BodyFormat == Outlook.OlBodyFormat.olFormatPlain && mailItem.Attachments.Count > 0) {
            attachments.AddRange(
                mailItem.Attachments.Cast<object>().Select(attachment => attachment as Outlook.Attachment));
            return attachments;
        }
    
        // if the body format is RTF ...
        if (mailItem.BodyFormat == Outlook.OlBodyFormat.olFormatRichText) {
            // add every attachment where the PR_ATTACH_METHOD property is NOT 6 (ATTACH_OLE)
            attachments.AddRange(
                mailItem.Attachments.Cast<object>().Select(attachment => attachment as Outlook.Attachment).Where(thisAttachment => (int)thisAttachment.PropertyAccessor.GetProperty(PR_ATTACH_METHOD) != 6));
        }
    
        // if the body format is HTML ...
        if (mailItem.BodyFormat == Outlook.OlBodyFormat.olFormatHTML) {
            // add every attachment where the ATT_MHTML_REF property is NOT 4 (ATT_MHTML_REF)
            attachments.AddRange(
                mailItem.Attachments.Cast<object>().Select(attachment => attachment as Outlook.Attachment).Where(thisAttachment => (int)thisAttachment.PropertyAccessor.GetProperty(PR_ATTACH_FLAGS) != 4));
        }
    
        return attachments;
    }
