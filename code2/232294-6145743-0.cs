    private void saveButton_Click(object sender, EventArgs args)
    {
        try
        {
            SaveFile(myFile); // The using statement will appear somewhere in here.
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
