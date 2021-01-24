    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CategoryItemPage
            {
                BindingContext = e.SelectedItem as CategoryItem
            });
        }
    }
