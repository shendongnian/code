    private void Form_Load(object sender, EventArgs e)
    {
        this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        this.Location = Screen.PrimaryScreen.WorkingArea.Location;
    }
