    private void Form1_Move(object sender, EventArgs e)
    {
        RefreshDataBindings();
    }
    public void RefreshDataBindings()
    {
        txtX.DataBindings.Clear();
        txtY.DataBindings.Clear();
        txtX.DataBindings.Add("Text", this.DesktopLocation.X, null);
        txtY.DataBindings.Add("Text", this.DesktopLocation.Y, null);
    }
