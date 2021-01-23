    private bool inSysMenu = false;
    void SystemMenuIcon_MouseDown( object sender, MouseButtonEventArgs e )
    {
      if( e.ClickCount == 1 && !inSysMenu )
      {
        inSysMenu = true;
        ShowSystemMenu(); //replace with your code
      }
      else if( e.ClickCount == 2 && e.ChangedButton == MouseButton.Left )
      {
        window.Close();
      }
    }
    void SystemMenuIcon_MouseLeave( object sender, MouseButtonEventArgs e )
    {
      inSysMenu = false;
    }
    void SystemMenuIcon_MouseUp( object sender, MouseButtonEventArgs e )
    {
      inSysMenu = false;
    }
