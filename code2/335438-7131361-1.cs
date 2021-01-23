    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (picEnlarger != null && picXmark != null)
        {
            if (txtSearch.Text == "")
            {
                picXmark.Visibility = Visibility.Visible;
                picEnlarger.Visibility = Visibility.Hidden; 
            }
            else
            {
                picXmark.Visibility = Visibility.Hidden;
                picEnlarger.Visibility = Visibility.Visible; 
            }
        }
    }
