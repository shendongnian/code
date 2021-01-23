    private bool isLoaded;
    
    protected override OnLoaded(...)
    {
       this.isLoaded = true;
    }
    
    private void CheckBox1_Checked(object sender, RoutedEventArgs e)
    {
      if (this.isLoaded)
      {
        radioButton1.IsEnabled = false;  // this is where exception is thrown
      }
    }
