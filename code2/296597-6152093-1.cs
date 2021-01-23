    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        Page1 page1 = (Page1)this.DataContext;
        string pin = twitpin.Text;    
        page1.ConnectToTwitter(pin, genratedToken);
        // Then you can update the label like so:
        page1.Label4.Text = "The text you want to display on the label";
        this.Close();   
    }
