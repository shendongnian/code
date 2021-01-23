        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
        }
        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            // Code to run when item is being sent
        }
