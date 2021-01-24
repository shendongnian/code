    public void SendEnMail(Office.IRibbonControl control) //OnAction Function
    {
        Outlook.Application oApp = new Outlook.Application();
        Outlook._MailItem myMail = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
        myMail.Display(true);
        Outlook.Application application = Globals.ThisAddIn.Application;
        application.ItemSend += new Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
    }
    void Application_ItemSend(object Item, ref bool Cancel)
    {
        string a = ((Microsoft.Office.Interop.Outlook.MailItem)Item).Body;
        System.Windows.Forms.MessageBox.Show(a);
        Cancel = true;
    }
