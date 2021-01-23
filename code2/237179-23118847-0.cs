        if (DataContext != null)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                this.IsEnabled = false;
                LoginDlg loginDlg = new LoginDlg();
                loginDlg.ShowDialog();
                if (!loginDlg.Success)
                {
                    /*-----------------------------------
                     * Log on failed -- terminate app...
                     *----------------------------------*/
                    ...termination logic removed...
                }
                this.IsEnabled = true;
            }));
        }
