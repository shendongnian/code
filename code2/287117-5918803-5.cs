    void FormViewName_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
      if (e.Exception != null)
      {
       if (((SqlException)e.Exception).Number == 2627)
       {
        e.ExceptionHandled = true;
        e.KeepInInsertMode = true;
        // Display error message.
       }
      }
    }
