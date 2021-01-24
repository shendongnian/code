    private void CloseForms()
    {
      foreach ( Form form in Application.OpenForms )
        if ( form != this && form.Visible )
          try
          {
            form.Close();
          }
          catch
          {
          }
    }
