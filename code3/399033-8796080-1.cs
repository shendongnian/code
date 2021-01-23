    private static string Decode(string input, string bodycharset)
    {
        Attachment attachment = Attachment.CreateAttachmentFromString("", "=?"+bodycharset+"?"+input+"?=");
        return (attachment.Name);
    }
