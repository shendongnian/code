    void TextBox_GotFocus( object sender, RoutedEventArgs e )
    {
        TextBox box = sender as TextBox;
        box.Text = string.Empty;
        box.Foreground = Brushes.Black;
        box.GotFocus -= TextBox_GotFocus;
    }
    
    void TextBox.LostFocus( object sender, RoutedEventArgs e )
    {
        TextBox box = sender as TextBox;
        if( box.Text.Trim().Equals( string.Empty ) )
        {
            box.Text = "Search...";
            box.Foreground = Brushes.LightGray;
            box.GotFocus += TextBox_GotFocus;
        }
    }
