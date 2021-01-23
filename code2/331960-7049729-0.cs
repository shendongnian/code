    private void button_Click(object sender, EventArgs e)
    {
        String name = (sender as Control).Name;
        int number = Int32.Parse(name.Substring(name.Length-1));
        trial(sender, e, this.Controls.Find("btnTrial"+number,true), this.Controls.Find("txtTrial"+number,true), Controls.Find("lblTrial"+number,true));
    }
