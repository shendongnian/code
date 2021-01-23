    private void MainForm_Load(object sender, EventArgs e)
    {
        Sell sell = new Sell();
        sell.Name = "mainSell";
        sell.Dock = DockStyle.Fill;
        this.Controls.Add(sell);
    }
    // Later...
    this.Controls.RemoveByKey("mainSell");
