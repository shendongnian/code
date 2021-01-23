    public void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                 
                    var result = this.ShowExceptionDialog(e.Exception);
                 
            }
            catch
            {
                RadMessageBox.Show("Fatal Dispatcher Error - the application will now halt.", Properties.Resources.CaptionSysErrMsgDlg,
                   MessageBoxButton.OK, MessageBoxImage.Stop, true);
            }
            finally
            {
                e.Handled = true;
                 
                // TERMINATE WITH AN ERROR CODE -1!
                //Environment.Exit(-1);
            }
        }
