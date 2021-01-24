    internal static IEnumerable<MailItem> GetSelectedEmails()
            {
                var list = new List<MailItem>();
                foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
                {
                    list.Add(email);
                }
                return list; 
            }
