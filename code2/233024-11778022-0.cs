            Microsoft.Office.Interop.Outlook.Application app = null;
            Microsoft.Office.Interop.Outlook._NameSpace ns = null;
            Microsoft.Office.Interop.Outlook.PostItem item = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
            //Microsoft.Office.Interop.Outlook.MAPIFolder subFolder = null;
            try 
            {
                app = new Microsoft.Office.Interop.Outlook.Application();
                ns = app.GetNamespace("MAPI");
                ns.Logon(null,null,false, false);
                inboxFolder = ns.GetDefaultFolder          (Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                //subFolder = inboxFolder.Folders["MySubFolderName"]; 
                //folder.Folders[1]; also works
                //Console.WriteLine("Folder Name: {0}, EntryId: {1}", subFolder.Name, subFolder.EntryID);
                //Console.WriteLine("Num Items: {0}", subFolder.Items.Count.ToString());
                for (int i = 1; i <= inboxFolder.Items.Count; i++)
                {
                    item = (Microsoft.Office.Interop.Outlook.PostItem)inboxFolder.Items[i];                   
                    foreach (Microsoft.Office.Interop.Outlook.Attachments attachment in item.Attachments)
                    {
                        // Process the "attachment" object as per your requirement!
                    }
                   
                 //Console.WriteLine("Item: {0}", i.ToString());
                 //Console.WriteLine("Subject: {0}", item.Subject); 
                 //Console.WriteLine("Sent: {0} {1}", item.SentOn.ToLongDateString(), item.SentOn.ToLongTimeString());
                 //Console.WriteLine("Categories: {0}", item.Categories);
                 //Console.WriteLine("Body: {0}", item.Body);
                 //Console.WriteLine("HTMLBody: {0}", item.HTMLBody); 
                }
            } 
            catch (System.Runtime.InteropServices.COMException ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ns = null;
                app = null;
                inboxFolder = null;
            }
