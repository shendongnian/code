     private void RegionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Region region =  ((sender as Picker).SelectedItem as Region);
            if (region != null)
            {
                StreetPicker.ItemsSource = region.Streets;
            }
            else {
                StreetPicker.ItemsSource = null;
            }
        }
