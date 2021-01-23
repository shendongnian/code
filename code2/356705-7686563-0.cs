    private void processMail( string entryId ) {
        Outlook.MailItem mail = Application.Session.GetItemFromID ( entryId ) as Outlook.MailItem;
        if (mail.Attachments.Count > 0) {
            foreach (Outlook.Attachment att in mail.Attachments)
                processAttachment ( att );
        }
    }
