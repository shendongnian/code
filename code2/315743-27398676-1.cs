        void edt_PopupOpened(object sender, RoutedEventArgs e)
        {
            LookUpEdit edt = (LookUpEdit)sender;
       
            Dispatcher.BeginInvoke((Action)(() =>
            {
                GridControl t = edt.GetGridControl();
               // do something with a column... t.Columns["RecId"].Visible = false;
            }), DispatcherPriority.Input);
        }
