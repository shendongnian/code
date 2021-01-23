    private void btnForm2_Click(object sender, EventArgs e)
    {
        Panelmain.Enabled = false; // optional
        this.Controls.Remove(Panelmain);
        Panel2.Enabled = true; // optional
        this.Controls.Add(Panel2);
    }
