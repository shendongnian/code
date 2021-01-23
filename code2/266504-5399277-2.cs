    private static void Control_Loaded(object sender,RoutedEventArgs e)
    {
      Control control = (Control)sender;
      if(ShouldShowWatermark(control))
      {
        ShowWatermark(control);
      }
      else
      {
        RemoveWatermark(control);
      }
    }
