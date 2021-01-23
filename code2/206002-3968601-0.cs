    private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      if (e.Source == this.button1)
      {
        Application.Current.Shutdown();
      }
    }
