    if (Clipboard.ContainsText(System.Windows.Forms.TextDataFormat.Text))
    {
        IDataObject data = Clipboard.GetDataObject();
        Outlook.Application oApp = new Outlook.Application();
        Outlook.MailItem oMsg = (Outlook.MailItem)data.GetData(DataFormats.Text, true);
    }
