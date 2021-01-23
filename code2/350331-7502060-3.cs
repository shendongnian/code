    private void btnForm3_Click(object sender, EventArgs e)
    {
        Panelmain.Enabled = false; // optional
        this.Controls.Remove(Panelmain);
        Panel3.Enabled = true; // optional
        this.Controls.Add(Panel3);
    }
