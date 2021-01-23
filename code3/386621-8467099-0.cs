    private void LoginButtonClick(object sender, RoutedEventArgs e)
    {
      var da = new DoubleAnimation(360, 0, new Duration(TimeSpan.FromSeconds(1)));
      var rt = new RotateTransform();
      loadingLabel.RenderTransform = rt;
      loadingLabel.RenderTransformOrigin = new Point(0.5, 0.5);
      da.RepeatBehavior = RepeatBehavior.Forever;
      rt.BeginAnimation(RotateTransform.AngleProperty, da);
    
      Thread thread = new Thread(new ThreadStart(LoadData));
      thread.Start();
    }
    
    void LoadData()
    {
      //Loading From Database
    
      // Use a Dispatch.BeginInvoke here to stop the animation
      // and do any other UI updates that use the results of the database load
    }
