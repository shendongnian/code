    private bool _toggle = true;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (_toggle)
      {
        ColumnToCollapse.Width = GridLength.Auto;
        abc.Visibility = Visibility.Collapsed;
        _toggle = false;
      }
      else
      {
        ColumnToCollapse.Width = new GridLength(1, GridUnitType.Star); 
        abc.Visibility = Visibility.Visible;
        _toggle = true;
      }
    }
