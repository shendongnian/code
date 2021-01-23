    it is, a sample
    
        private string GetSmtp(Outlook.MailItem item)
            {
                try
                {
                    if (item == null || item.Recipients == null || item.Recipients[1] == null) return "";
                    var outlook = new Outlook.Application();
                    var session = outlook.GetNamespace("MAPI");
                    session.Logon("", "", false, false);
                    var entryId = item.Recipients[1].EntryID;
                    string address = session.GetAddressEntryFromID(entryId).GetExchangeUser().PrimarySmtpAddress;
                    if (string.IsNullOrEmpty(address))
                    {
                        var rec = item.Recipients[1];
                        var contact = rec.AddressEntry.GetExchangeUser();
                        if (contact != null)
                            address = contact.PrimarySmtpAddress;
                    }
                    if (string.IsNullOrEmpty(address))
                    {
                        var rec = item.Recipients[1];
                        var contact = rec.AddressEntry.GetContact();
                        if (contact != null)
                            address = contact.Email1Address;
                    }
                    return address;
                }
                finally
                {
    
                }
            }
