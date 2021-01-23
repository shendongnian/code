    public void bgCombo(DataGridView dg)
    {
        foreach (DataGridViewRow row in dg.Rows)
        {
            DataGridViewComboBoxCell dgc = new DataGridViewComboBoxCell();
            dgc.Value = row.Cells["Department"].Value;
            row.Cells["Department"] = dgc;
        }
    }
