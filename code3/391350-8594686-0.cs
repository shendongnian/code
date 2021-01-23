    void buttonImport_Click(object sender, DoWorkEventArgs e)
    {
        Task.Factory
          .StartNew( () => return EngineBllUtility.GetNotImportedFiles(connectionString))
          .ContinueWith( t =>
        {        
            try
            {
                if (t.Result != null)
                {
                     importFileGridView.DataSource = t.Result.Tables[0];
                }
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
