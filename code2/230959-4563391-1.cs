            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.NameSpace oNS = (Outlook.NameSpace)oApp.GetNamespace("MAPI");
                oNS.Logon(Missing.Value, Missing.Value, false, true);
                Outlook.MAPIFolder theInbox = oNS.Folders["Mailbox - Name Here"].Folders["Inbox"];
                
                ....Do you want with that Folder here....
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
