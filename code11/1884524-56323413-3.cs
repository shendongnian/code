    private void MyListBx_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string SelectedColor = (myListBx.SelectedItem as ListBoxItem).Content.ToString();
    
        switch (SelectedColor)
        {
            case "Yellow":
                button.Background = Brushes.Yellow;
                break;
            case "Green":
                button.Background = Brushes.Green;
                break;
            case "Pink":
                button.Background = Brushes.Pink;
                break;
        }
    }
 
