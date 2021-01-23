            readonly Outlook.Application _outlookApp = new Outlook.Application();
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _outlookApp.ItemSend += new ApplicationEvents_11_ItemSendEventHandler(OutlookAppItemSend);
        }
        void OutlookAppItemSend(object item, ref bool cancel)
        {
            if (item is Outlook.AppointmentItem)
            {
                var appt = item as Outlook.AppointmentItem;
                foreach (Outlook.Recipient recipient in appt.Recipients)
                {
                    MessageBox.Show(string.Format("Rctp {0} ", recipient.Name));
                }
            }....
