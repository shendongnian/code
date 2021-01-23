    {
      DataTable dt = Admin_User_Functions.Admin_KitItems_GetItems()
    
      try
      {
         // .. code inside using statement
      }
      finally
      {
        if (dt != null)
          ((IDisposable)dt).Dispose();
      }
    }
