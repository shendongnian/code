    void eAdvBandedGridView1_ShownEditor(object sender, EventArgs e)
    {
        GridView view = sender as GridView;
        if (view.FocusedColumn.FieldName == "CenterID" && view.ActiveEditor is LookUpEdit)
        {
            LookUpEdit editor = view.ActiveEditor as LookUpEdit; 
            vVoucherItemInfoDTO item = view.GetFocusedRow() as vVoucherItemInfoDTO;
            if (lastFetchedAccount == null || lastFetchedAccount.ID != item.AccountID)
            {
                lastFetchedAccount = accountServiceClient.GetAccountInfo(item.AccountID);
            }
            if (lastFetchedAccount.AllowAllCenters)
                editor.Properties.DataSource = GlobalDataStore.CenterList;
            else
                editor.Properties.DataSource = lastFetchedAccount.AllowedCenterList;
        }
    }
