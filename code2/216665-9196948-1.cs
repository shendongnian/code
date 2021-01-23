    string[] names;
    Outlook.AddressLists addrLists = Application.Session.AddressLists; 
    Outlook.AddressList gal = addrLists["Global Address List"];
    //for a distrubution list do this...
    Outlook.AddressEntry entry = gal.AddressEntries["distribution list"];
    Outlook.ExchangeDistributionList exchDL = entry.GetExchangeDistributionList();
    Outlook.AddressEntries addrEntries = exchDL.GetExchangeDistributionListMembers();
    names = new string[addrEntries.Count];
    for (int i = 0; i < addrEntries.Count; i++)
    {
        Outlook.AddressEntry exchDLMember = addrEntries[i];
        names[i] = exchDLMember.Name;
    }
    return names;
    //for an individual you could do something like this...
    Outlook.AddressEntry entry = gal.AddressEntries["contact nickname"];
    Outlook.ContactItem contact = entry.GetContact();
    string name = contact.NickName;
    string email = contact.Email1Address;
