    // Horrible code ahead
    private void pagesSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        Mapper.Map(settings, pagesSettingsForm);
        if (pagesSettingsForm.ShowDialog() == DialogResult.OK)
            Mapper.Map(pagesSettingsForm, settings);
        pagesSettingsForm.Dispose();
    }    
