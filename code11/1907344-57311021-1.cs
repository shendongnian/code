private void GenerateItemMessage(object item, string operation)
{
    MailItem mi = item as Outlook.MailItem;
    MessageBox.Show(String.Format("MailItem {0} will be {1}", mi.Subject, operation));
}
The scope of `mi` object is limited by the method where it is declared. The `GC` can swipe it from the heap at any point of time. So, you need to declare it at the global scope:
MailItem mi = null;
private void GenerateItemMessage(object item, string operation)
{
    mi = item as Outlook.MailItem;
    MessageBox.Show(String.Format("MailItem {0} will be {1}", mi.Subject, operation));
}
Or you may consider maintaining a list of objects if you going to handle many of them simultaneously.
You should DO so everywhere in the code, for example, looks like you didn't do so for the following sample:
private void _application_ItemLoad(object Item)
{
    ((Outlook.ItemEvents_10_Event)Item).ReplyAll += new Outlook.ItemEvents_10_ReplyAllEventHandler(ThisAddIn_ReplyAll);
}
You will not get the `ReplyAll` event fire after the `_application_ItemLoad` method finishes. You need to keep objects alive if you want to get events fired:
Outlook.ItemEvents_10_Event _item;
private void _application_ItemLoad(object Item)
{
    _item = (Outlook.ItemEvents_10_Event)Item;
    _item.ReplyAll += new Outlook.ItemEvents_10_ReplyAllEventHandler(ThisAddIn_ReplyAll);
}
