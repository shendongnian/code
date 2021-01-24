    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
       string result= await  DisplayActionSheet("Details", "Close", null, "Cash", "Delete", "");
       if(result=="Delete")
        {
            int position = DebtsList.TemplatedItems.GetGlobalIndexOfItem(e.Item);
            mySource.RemoveAt(position);
            DebtsList.ItemsSource = mySource;
        }
    }
