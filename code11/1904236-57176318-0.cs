     private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
     {
         ListView brandBox = sender as ListView;
        if(brandBox != null)
        {
            Brand selectedBrand = brandBox.SelectedItem as Brand;
            if(selectedBrand != null)
            {
                this.NavigationService.Navigate(new CarsPurchaseable(selectedBrand));
            }
        }
    }
