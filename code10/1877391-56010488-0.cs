    for (int i = FolderItems.Count; i >= 1; i--)
    {
      object oItem = FolderItems[i];
      Outlook.ContactItem oContact = (oItem as Outlook.ContactItem);
      if (oContact  != null)
      {
        ...
        Marshal.ReleaseComObject(oContact);
      }
      Marshal.ReleaseComObject(oItem);
    }
                        {
