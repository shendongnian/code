    const string PropTag = "http://schemas.microsoft.com/mapi/proptag/";
    var filter = "@SQL=" + "\"" + PropTag
             + "0x0037001E" + "\"" + " ci_phrasematch " + "\'" + strFilter + "\'";
    Outlook.Table table = inbox.GetTable(filter, Outlook.OlTableContents.olUserItems);
    while (!table.EndOfTable)            
    {
            Outlook.Row nextRow = table.GetNextRow();
            try
            {
                Outlook.MailItem mi;
                try
                {
                    string entryId = nextRow["EntryID"];
                    var item = outlookNameSpace.GetItemFromID(entryId);
                    mi = (Outlook.MailItem)item;
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("Cannot cast mail item, so skipping. Error: {0}", e);                       
                    continue;
                } 
                //Extract the attachments here and archive or reply - put your logic here
            }
            catch (Exception e)
            {   
                Console.WriteLine("An error occurred: '{0}'", e);
            }
     }  
