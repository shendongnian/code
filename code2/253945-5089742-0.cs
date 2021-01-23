    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
       Properties.Settings.Default.MySize = this.Size;
       Properties.Settings.Default.MyLoc = this.Location;
       Properties.Settings.Default.Save();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
       this.Size = Properties.Settings.Default.MySize;
       this.Location = Properties.Settings.Default.MyLoc;
    }
