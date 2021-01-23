        void Application_NewMailEx(string EntryIDCollection)
        {    
            Outlook.MailItem newMail = (Outlook.MailItem) Application.Session.GetItemFromID(EntryIDCollection, System.Reflection.Missing.Value);
            // do whatever you want with the new email...
        }
