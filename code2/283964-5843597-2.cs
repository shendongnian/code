    private void _ws_InitializeConnexionCompleted(object sender, 
                                                  InitializeConnexionCompletedEventArgs e)
       {
           if (e.Error != null)
           {
               this.Member = e.Result;
               webCallCompletedAction(); 
           }
           else
           {
               MessageBox.Show("error.");
           }
       }
    }
