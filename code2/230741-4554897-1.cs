    void Button_Click(object sender, RoutedEventArgs e)
    {
      Button b = sender as Button;  // sender is the button user clicked
      MyDataObject data = b.DataContext as MyDataObject;  // data is the MyDataObject for that row
      // ...
    }
