    private void Form1_Load(object sender, EventArgs e)
    {
        this.Location = new Point(Properties.Settings.Default.LocationX, Properties.Settings.Default.LocationY);
        this.Width = Properties.Settings.Default.WindowWith;
        this.Height = Properties.Settings.Default.WindowHeight;
    }
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        Properties.Settings.Default.LocationX = this.Location.X;
        Properties.Settings.Default.LocationY = this.Location.Y;
        Properties.Settings.Default.WindowWith = this.Width;
        Properties.Settings.Default.WindowHeight = this.Height;
        Properties.Settings.Default.Save();
    }
