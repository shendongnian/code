    private Dictionary<string, Store> storeDictionary = new Dictionary<string, Store>();
    private void MailBoxOptions_Load(object sender, EventArgs e)
    {
        Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
        Microsoft.Office.Interop.Outlook.NameSpace ns = application.GetNamespace("MAPI");
        Stores stores = ns.Stores;
        foreach (var store in Globals.ThisAddIn.Application.Session.Stores.Cast<Microsoft.Office.Interop.Outlook.Store>().Where(c => c.ExchangeStoreType == Microsoft.Office.Interop.Outlook.OlExchangeStoreType.olExchangeMailbox))
        {
            if (store != null)
            {
                mailBoxes.Items.Add(store.DisplayName);
                storeDictionary.Add(store.DisplayName, store); // Add the items to the dictionary
            }
            else
            {
                MessageBox.Show("You don't have access to any shared mail-inbox.");
            }
        }
    }
