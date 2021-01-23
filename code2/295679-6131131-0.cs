        public static List<Outlook.MailItem> SelectedMail(Outlook.Selection selectedItems)
        {
            Contract.Requires(selectedItems != null);    //always a good idea
            Contract.Requires(selectedItems.Count > 0);
            // can't promise this
            // Contract.Ensures(Contract.Result<List<Outlook.MailItem>>().Count > 0);  
            List<Outlook.MailItem> selectedMails = new List<Outlook.MailItem>();
            foreach (object obj in selectedItems)
            {
                if (obj is Outlook.MailItem)
                {
                    selectedMails.Add((Outlook.MailItem)obj);
                }
            }
            // and then w/o the promise we don't need this
            // Contract.Assume(selectedMails.Count > 0);
            return selectedMails;
        }
        void SomeMethod()
        {
           var selected = SelectedMail(...);
           if (selected.Count > 0)
              SaveAttachment(selected, "file")
           else
              // you need a plan here anyway
            
        }
