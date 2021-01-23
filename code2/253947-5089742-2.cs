    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
       Properties.Settings.Default.Size = this.Size;
       Properties.Settings.Default.Location = this.Location;
       Properties.Settings.Default.Save();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
       this.Size = Properties.Settings.Default.Size;
       this.Location = Properties.Settings.Default.Location;
    }
