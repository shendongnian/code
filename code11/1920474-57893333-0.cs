    private void Filtriraj_clanove_Click(object sender, EventArgs e)
    {
        // Read name/gender/status from the UI
        var name = pretraga_ime_prezime.Text;
        var sekcija = cmbSekcija.Text;
        var active = optStatus.SelectedIndex == 0 ? true : false; // True for active, False for inactive
        // Get datasource
        var dtSource = baza_filter_clanova.DataSource as DataTable;
        var sbFilter = new StringBuilder();
        // Filter name
        sbFilter.AppendLine($"(ime LIKE '{name}%' OR prezime LIKE '{name}%') AND ");
        // Filter active
        sbFilter.AppendLine($"(status = '{active}') AND ");
        // Filter male/female
        sbFilter.AppendLine($"(sekcija = '{sekcija}') ");
        // Apply row filters
        dtSource.DefaultView.RowFilter = sbFilter.ToString();
    }
