    private void ResetForm()
    {
        string path = @"C:\Users\pc\Documents\textfolder";
        comboBoxSaveCap.DataSource = null; // Clear the previous content
        comboBoxSaveCap.DataSource = new DirectoryInfo(path).GetFiles("*.cap");
    }
    void comboBoxSaveCap_SelectedIndexChanged(object sender, EventArgs e)
    {
        var f = comboBoxSaveCap.SelectedItem as FileInfo;
        if(f != null)
        { 
            Console.WriteLine(f.FullName);
        }
    }
