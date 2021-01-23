    private void BW_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
           
         if( e.Cancelled )
            {
                MessageBox.Show( e.Result.ToString());
                return;
            }
    }
