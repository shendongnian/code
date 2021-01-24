    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = e.SelectedItem as RooterMasterDetailPageMenuItem;
        if (item == null)
            return;
    
        var page = (Page)Activator.CreateInstance(item.TargetType);
        page.Title = item.Title;
        // remove navigationpage
        Detail = page;
        IsPresented = false;
    
        MasterPage.ListView.SelectedItem = null;
    }
