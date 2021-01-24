    private void Form1_Load(object sender, EventArgs e)
    {
        txtX.DataBindings.Add("Text", this.DesktopLocation.X, null);
        txtY.DataBindings.Add("Text", this.DesktopLocation.Y, null);
    }
