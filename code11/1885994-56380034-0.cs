    private void button_Click(object sender, System.EventArgs e)
    {
        var btn = sender as BunifuThinButton2;
        var id = int.Parse(btn.Name.Split(new [] {'_'})[1]);
    }
