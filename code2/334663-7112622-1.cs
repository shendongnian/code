    private void AddRecordButton_Click(object sender, EventArgs e)
    {
        try
        {
           // code to add the record to your database
           //then use the DialogResult   OK
           DialogResult = DialogResult.OK
        }
        catch
        {
           //if it fails set DialogResult to Abort
           DialogResult = DialogResult.Abort
        }
    
    }
