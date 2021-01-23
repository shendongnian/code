        void custodyRptItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (CustodyItem curItem in CustodyControl.SelectedItems)
            {
                ThreadPool.QueueUserWorkItem(ShowChainOfCustodyReport, curItem);
            }
        }
        void ShowChainOfCustodyReport(object context)
        {
            CustodyItem item = context as CustodyItem;
            if (item == null) return;
            if (InvokeRequired)
            {
                Action<object> a = ShowChainOfCustodyReport;
                Invoke(a, context);
            }
            else
            {
                CustodyReport report = new CustodyReport(item);
                report.Show();
            }
        }
