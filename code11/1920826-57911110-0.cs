    public void AutographRequest_Click(Office.IRibbonControl control)
            {
                Outlook.Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
                if (explorer != null)
                {
                    Outlook.Selection selection = explorer.Selection;
                    if (selection.Count >= 1)
                    {  
                        Outlook.MailItem mailItem = selection[1] as Outlook.MailItem;
                        if (mailItem != null) //could be something other than MailItem
                        {
                            Outlook.MailItem response = mailItem.ReplyAll();
    
                            response.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
                            response.HTMLBody = "<p>Text</p> " + response.HTMLBody;
                            response.Send();
                            mailItem.Delete();
                        }
                    }
                }
        }
