    private async void Button1_Click(object sender, EventArgs e) // + async
    {
        richTextBox1.Text = "Scanning drives, please wait...";
        await PopulateComboBox(); // + await
    }
    async Task PopulateComboBox() // async Task instead of void
    {
        System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
        foreach (System.IO.DriveInfo drive in drives)
        {
            if (await Task.Run(() => drive.IsReady)) // + await Task.Run(() => ...)
            {
                comboBox1.Items.Add(drive.Name + drive.VolumeLabel);
            }
            else
            {
                comboBox1.Items.Add(drive.Name);
            }
        }            
    }
