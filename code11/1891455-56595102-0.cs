        ((Outlook.ItemEvents_10_Event)mail).Send += new Microsoft.Office.Interop.Outlook.ItemEvents_10_SendEventHandler(SaveSentMail);
    
        static void SaveSentMail(ref bool Cancel)
        {
           mail.SaveAs(mydesktop+ ....);
        }
