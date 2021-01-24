    private void reject(object sender, EventArgs args)
    {
        var selectedItems = (ListView /* or ProductListView*/)sender;
        foreach (var item in selectedItems )
        {
           ProductsListView.Select(item).Remove(); //--> update here
        }
        DisplayAlert("Rejected","Request Rejected!!", "OK");
    }
