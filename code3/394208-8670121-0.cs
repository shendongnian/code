    private void GetAllImports(object x)
    {
        DataSet temp = EngineBllUtility.GetAllImportFiles(connectionString);
        if (temp != null)
        {
            // Use Control.Invoke to push this onto the UI thread
            importFileGridView.Invoke((Action) 
                () => 
                {
                    importFileGridView.DataSource = temp.Tables[0];
                });
        }
        else
            MessageBox.Show("There were no results. Please try a different search", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
