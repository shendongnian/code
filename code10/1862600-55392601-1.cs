    private void reject(object sender, EventArgs args)
    {
        ProductListView selectedItems = (ProductListView)sender;
        foreach (var item in selectedItems )
        {
           ProductsListView.ItemSelected.Remove(item);
        }
        DisplayAlert("Rejected","Request Rejected!!", "OK");
    }
