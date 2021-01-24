using System.Runtime.InteropServices;
// ...
private void CreateItemBasedOnTemplate(Outlook.Application Application)
{
    Outlook.NameSpace ns = null;
    Outlook.MAPIFolder containerFolder = null;
    Outlook.MailItem item = null;
    Outlook.MailItem movedItem = null;
    try
    {
        ns = Application.GetNamespace("MAPI");
        containerFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        item = Application.CreateItemFromTemplate(@"D:\MyTemplate.msg", containerFolder) 
            as Outlook.MailItem;
        // the item was created in the Drafts folder regardless
        // that is why we move it to the Inbox folder
        movedItem = item.Move(containerFolder) as Outlook.MailItem;
        movedItem.Save();
        movedItem.Display();
    }
    catch (COMException ex)
    {
        if (ex.ErrorCode == -2147287038)
           System.Windows.Forms.MessageBox.Show(ex.Message,
               "Can't find the template...");
        else
           System.Windows.Forms.MessageBox.Show(ex.Message,
               "An error was occurred when creating a new item from template...");
    }
    finally
    {
        if (movedItem != null) Marshal.ReleaseComObject(movedItem);
        if (item != null) Marshal.ReleaseComObject(item);
        if (containerFolder != null) Marshal.ReleaseComObject(containerFolder);
        if (ns != null) Marshal.ReleaseComObject(ns);
    }
}
You may find the [How To: Create a new Outlook message based on a template][2] article helpful.
  [1]: https://docs.microsoft.com/en-us/office/vba/api/outlook.application.createitemfromtemplate
  [2]: https://www.add-in-express.com/creating-addins-blog/2011/08/31/outlook-create-message-based-on-template/
