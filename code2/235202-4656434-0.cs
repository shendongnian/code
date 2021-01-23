public class Outlook
{
    readonly Microsoft.Office.Interop.Outlook.Items       _items;
    readonly Microsoft.Office.Interop.Outlook.NameSpace   _ns;
    readonly Microsoft.Office.Interop.Outlook.MAPIFolder  _inbox;
    readonly Microsoft.Office.Interop.Outlook.Application _application = new Microsoft.Office.Interop.Outlook.Application(); 
        
    public Outlook()
    {
        _ns    = _application.Session;
        _inbox = _ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
        _items = _inbox.Items;
        foreach (var item in _items)
        {
            var mail    = item as Microsoft.Office.Interop.Outlook.MailItem;
            var subject = mail.Subject;
        }
    }
}
