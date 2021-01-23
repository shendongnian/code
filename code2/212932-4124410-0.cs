    Console.WriteLine("Enter a ; delimited list of domain\alias that need to be added:");
    string sAliases = Console.ReadLine(); //captures whatever the user entered
    string sValueToAddToFieldInSP = ""; //used to build the full string needed for the person field
    
    string sAllContacts = "";
    
    using (SPSite site = new SPSite(“http://sites/site/yoursite”))
    {
        site.AllowUnsafeUpdates = true;
        using (SPWeb web = site.RootWeb)
        {
            web.AllowUnsafeUpdates = true;
            string[] aAliases = sAliases.Split(';');
            foreach (string sAlias in aAliases)
            {
                SPUser user = web.EnsureUser(sAlias);
                sAllContacts += user.ID.ToString() + ";#" + user.LoginName.ToString() + ";#";
            }
            web.Update();
        }
    }
    
    if (sAllContacts.EndsWith(";#"))
    {
        sAllContacts = sAllContacts.Substring(0, sAllContacts.Length - 2);
    }
    
    //add the list item
    SPList l = web.Lists["<name of your list>"];
    SPListItem li= l.Items.Add();
    li["Title"] = sAllContacts ;
    li["MyPerson"] = sAllContacts ;
    li.Update();
    Console.WriteLine("Done");
