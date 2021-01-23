    public void tsbNoviRacun()
    {
        if (racunuc == null)
        {
            racunuc = new RacunUC();
            racunuc.Dock = DockStyle.Fill;
            Controls.Add(racunuc);
        }
        racunuc.BringToFront();
    }
    
    private void tsbNoviRacun_Click(object sender, EventArgs e)
    {
        tsbNoviRacun();
    }
