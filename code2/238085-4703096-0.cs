    Microsoft.Office.Interop.Outlook.NameSpace ns = Globals.ThisAddIn.Application.GetNamespace("MAPI");
      Microsoft.Office.Interop.Outlook.MAPIFolder contactsFld = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts);
      Microsoft.Office.Interop.Outlook.Table tb = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts).GetTable(null, Microsoft.Office.Interop.Outlook.OlItemType.olContactItem);
      tb.Columns.RemoveAll();
      tb.Columns.Add("Email1Address");
      tb.Columns.Add("FullName");
      object[,] otb = tb.GetArray(100000) as object[,];
      int len = otb.GetUpperBound(0);
      for (int i = 0; i < len; i++)
      {
        if (otb[i, 0] == null)
        {
          continue;
        }
        Contacts.Add(new ContactItem() { ContactDisplay = otb[i, 1].ToString(), ContactEmail = otb[i, 0].ToString() });
      }
