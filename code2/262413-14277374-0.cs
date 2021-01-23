        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
                   
           this.Application.Inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);          
        }
     void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
            {
                try
                {
                    Outlook.MailItem tmpMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                    if (tmpMailItem != null)
                    {
                        if (Inspector.CurrentItem is Outlook.MailItem)
                        {
                            tmpMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                            string to=   tmpMailItem.To;
                            string body = tmpMailItem.Body;
                        }
                    }
                 }
                catch
                {
    
                }
            }
