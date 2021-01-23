      Selection selectedItems = Globals.ThisAddIn.Application.ActiveExplorer().Selection; 
      for (int i = 1; i <= selectedItems .Count; i++)
      {
        object selection= selectedItems[i];
        MailItem mi = selection as MailItem;
        if (mi != null) //can have items other than MailItem
        {
          UserProperties props = mi.UserProperties;
          UserProperty up = props .Find("MyProp");
          if (up != null)
          {
            ...
            Marshal.ReleaseComObject(up);
          };
          Marshal.ReleaseComObject(props);
          Marshal.ReleaseComObject(mi);
        }; //if   
        Marshal.ReleaseComObject(selection);
      }; //for  
