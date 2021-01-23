    private void unitToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        if (britishUnitToolStripMenuItem.Checked==true)
        {
            sIUnitToolStripMenuItem.Checked = false;
            label21.Text = "lb/hr";
            label22.Text = "lb/FT3";
        }
        else if (sIUnitToolStripMenuItem.Checked==true)
        {
            britishUnitToolStripMenuItem.Checked = false;
            label21.Text = "Kg/hr";
            label22.Text = "Kg/m3";
        }
    }
