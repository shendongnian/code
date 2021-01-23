    public void dgCombo(DataGridView dg)
    {
        foreach (DataGridViewRow row in dg.Rows)
        {
            DataGridViewComboBoxCell dgc = new DataGridViewComboBoxCell();
            row.Cells["Department"] = dgc;
        }
    }
