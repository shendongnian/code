    public void lblDayz_Click(object sender, EventArgs e)
    {
        Label clickedLabel = sender as Label; 
        clickedLabel.BackColor = Color.FromArgb(176, 180, 43);
        clickedLabel.ForeColor = Color.White;
    }
