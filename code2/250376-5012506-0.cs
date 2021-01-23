    <TextBox LostFocus="myText_LostFocus" x:Name="myText" Height="38" Margin="0,72,6,0" VerticalAlignment="Top" HorizontalAlignment="Right" Width="135"></TextBox>
    
    void myText1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      base.OnPreviewMouseDown(e);
      if (e.RightButton == MouseButtonState.Pressed)
      {
        // added next line
        myText1.Focus();
        con.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
        con.IsOpen = true;
        IInputElement focusedElement = FocusManager.GetFocusedElement(this);
      }
    }
    
    private void myText_LostFocus(object sender, RoutedEventArgs e)
    {
      e.Handled = true;
    }
