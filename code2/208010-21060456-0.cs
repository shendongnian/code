    private void Panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(panaroma.SelectedIndex == 1) //Your required page index
                ApplicationBar.IsVisible = true;
            else
                ApplicationBar.IsVisible = false; // other pages will be hidden            
        }
