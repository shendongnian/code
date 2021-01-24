    void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
    {
        object item = Inspector.CurrentItem;
        Outlook.MailItem mailItem = item as Outlook.MailItem;
        if (mailItem != null)
        {
            if (mailItem.EntryID == null)
            {
                mailItem.Subject = "This text was added by using code";
                mailItem.Body = "This text was added by using code";
            }
            Marshal.ReleaseComObject(mailItem);
        }
        Marshal.ReleaseComObject(item);
    }
