    private TaskCompletionSource<bool> Sf_collectionDDL_SelectedIndexChangedAsync;
    private async void Sf_collectionDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Sf_collectionDDL_SelectedIndexChangedAsync = new TaskCompletionSource<bool>();
        try
        {
            var cmb = sender as SfComboBox;
            //...
            await GetCollectionDates(collectionName);
            //...
            sf_datesDDL.MaxDropDownItems = 12;
            Sf_collectionDDL_SelectedIndexChangedAsync.SetResult(true);
        }
        catch (Exception ex)
        {
            Sf_collectionDDL_SelectedIndexChangedAsync.SetException(ex);
        }
    }
