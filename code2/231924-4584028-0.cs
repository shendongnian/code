    Sell sell = new Sell();
    private void MainForm_Load(object sender, EventArgs e)
    {
        sell.Dock = DockStyle.Fill;
        this.Controls.Add(sell);
    }
    // other scope
    this.Controls.Remove(sell);
