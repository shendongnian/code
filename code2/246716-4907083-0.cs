    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new System.Windows.Threading.DispatcherOperationCallback(delegate
    {
        AccountSyncOptions getData = new AccountSyncOptions(syncProgress, lblStatus, tblLogins, cboFilter, searching, searchString, btnClearSearch);
        getData.retrieveLocalData();
        getData.retrieveOnlineData();
        return null;
    }), null);
