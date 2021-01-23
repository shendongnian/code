List<string> entryids = new List<string>();
foreach (var selection in Globals.ThisAddIn.Application.ActiveExplorer().Selection)
{
	MailItem mi = selection as MailItem;
	if (mi != null)
	{
		// For any reason it's not possible to change the mail here
		
		entryids.Add(mi.EntryID);
		Marshal.ReleaseComObject(mi);
		mi = null;
			
	}
}
foreach (string id in entryids)
{
	MailItem mi = Globals.ThisAddIn.Application.ActiveExplorer().Session.GetItemFromID(id);
	// My changes on the mail
	mi.Save();
	Marshal.ReleaseComObject(mi);
	mi = null;
}
