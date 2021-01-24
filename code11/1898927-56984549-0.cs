    Application oApp = Globals.ThisAddIn.Application;
            NameSpace oNs = oApp.GetNamespace("MAPI");
            MAPIFolder oInbox = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            Items oItems = oInbox.Items;
            MailItem oForm = oItems.Add("IPM.Note");
            oForm.Display(false);
