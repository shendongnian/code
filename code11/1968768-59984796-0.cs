    private void button1_Click(object sender, EventArgs e)
    {
        var task = new Thread(() => GetFile());
        task.SetApartmentState(ApartmentState.STA);
        task.Start();
        task.Join();
    }
    private static void GetFile()
    {
        try
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "Dat files |*.dat";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = fileDialog.FileName;
                Process.Start(path);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
