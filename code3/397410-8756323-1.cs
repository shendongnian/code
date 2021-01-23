    this.grid1 = ((System.Windows.Controls.Grid)(target));
    this.grid1.MouseLeftButtonDown += new MouseButtonEventHandler(grid1_MouseLeftButtonDown);
    this.grid1.MouseRightButtonDown += new MouseButtonEventHandler(grid1_MouseRightButtonDown);
             
    void grid1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
       if( leftClicked < (e.Timestamp - maxTimeBetweenClicks) )
       {
          MouseButtonEventArgs fakeLeftMouse = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.LeftButton);
          grid1_MouseLeftButtonDown(sender, e);
       }
    
       leftClicked = 0;
       throw new NotImplementedException();
    }
    void grid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       leftClicked = e.Timestamp;
    
       throw new NotImplementedException();
    }
