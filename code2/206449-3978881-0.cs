    private void ListView1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
       // Show messagebox and get response
       if(UserDoesntWantToSave)       
       {
          // Cancel the event
          e.Cancel = true;
       }
    }
