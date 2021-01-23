    void OnLoad(object sender, RoutedEventArgs e)
    {
      this.Owner.Hide();
    }
    void Closed(object sender, RoutedEventArgs e)
    {
      this.Owner.Show();
    }
