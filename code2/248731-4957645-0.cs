    private static bool CanCallUnmanagedCode
    {
     get
      {
      try
      {
        new SecurityPermission(SecurityPermissionFlag.Unmanage dCode).Demand();
      }
      catch(SecurityException)
      {
        return false;
      }
      return true;
     }
    }
    
    void Page_Load(Object sender, EventArgs e)
    {
      if (CanCallUnmanagedCode)
        Label1.Text = "This page can call unmanaged code.";
    else
        Label1.Text = "This page can NOT call unmanaged code.";
    }
