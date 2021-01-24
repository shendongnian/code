     public partial class ThisAddIn
     {
        Outlook.Items items=null;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
         Outlook.MAPIFolder inbox = 
        Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        items=inbox.Items;
        items.ItemAdd += new 
        Outlook.ItemsEvents_ItemAddEventHandler(InboxFolderItemAdded);
    }
    private void InboxFolderItemAdded(object Item)
    {
        if (Item is Outlook.MailItem)
        {
            Debug.WriteLine("I'm in!");
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            int[] answer = Predict(mail);
            if(answer[0] == 0) // Not spam
            {
                Outlook.MAPIFolder inboxFolder = ((Outlook.MAPIFolder)this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox));
                mail.Move(inboxFolder);
            }
            else if(answer[0] == 1) // Spam
            {
                Outlook.MAPIFolder junkFolder = ((Outlook.MAPIFolder)this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderJunk));
                mail.Move(junkFolder);
            }
        }
    }
    private int[] Predict(Outlook.MailItem mailBody)
    {
        Debug.WriteLine("I'm inside in predict function");
        double[]feature = featureExtraction.findFeatureIncomingMail(mailBody.Body);
        int[] answer = tree.Decide(feature);
        return answer;
     }
    }
