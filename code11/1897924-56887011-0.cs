    private async void EntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue != null)
        {
            var entry = sender as Entry;
            ((MyViewModel)entry).IsAllEntriesFilled();
        }
    }
