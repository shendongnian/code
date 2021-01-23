    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (picXmark != null && picEnlarger != null)
        {
            picXmark.Visibility = Visibility.Visible;
            picEnlarger.Visibility = Visibility.Hidden;
        }
    }
     
