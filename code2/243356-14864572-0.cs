    DataTable dt = new DataTable();
    dt.Columns.Add("Item");
    dt.Columns.Add("Value");
    dt.Rows.Add("Item 1", "0");
    dt.Rows.Add("Item 2", "1");
    dt.Rows.Add("Item 3", "2");
    dt.Rows.Add("Item 4", "3");
    for (int i = 0; i < dvg.Rows.Count; i++)
    {
        DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dvg.Rows[i].Cells[1];
        comboCell.DisplayMember = "Item";
        comboCell.ValueMember = "Value";
        comboCell.DataSource = dt;
    };
