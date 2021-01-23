            try
            {
                OutLook.Application oApp = new OutLook.Application();
                OutLook.NameSpace oNS = (OutLook.NameSpace)oApp.GetNamespace("MAPI");
                oNS.Logon(Missing.Value, Missing.Value, false, true);
                OutLook.MAPIFolder theInbox = oNS.Folders["Mailbox - Name Here"].Folders["Inbox"];
                
                ....Do you want with that Folder here....
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
