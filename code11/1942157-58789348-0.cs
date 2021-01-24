    private void ContentControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      //Unpack the sender
      Image source = (Image)Sender;
    
      //Get the click point
      Point clickPoint = e.GetPosition(source);
    
      //There is more then 1 height Property in WPF. 
      //The Actuall one is what you are looking for
      //Unfortunately you get doubles for this and int for the other. Consider general advise regarding double math
      double ElementHeight = source.ActualHeight;
      double ElementWidth = source.ActualWidth;
    
      //Do what you need to find the relative position
    
      //Part 2
    }
