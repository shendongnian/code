    DataTable dt = new DataTable();
    dt.Columns.Add("Item");
    dt.Columns.Add("Value");
    dt.Rows.Add("Item1", "0");
    dt.Rows.Add("Item1", "1");
    dt.Rows.Add("Item1", "2");
    dt.Rows.Add("Item1", "3");
    DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
    cmb.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
    cmb.DefaultCellStyle.ForeColor = Color.BlueViolet;
    cmb.FlatStyle = FlatStyle.Flat;
    cmb.Name = "ComboColumnSample";
    cmb.HeaderText = "ComboColumnSample";
    cmb.DisplayMember = "Item";
    cmb.ValueMember = "Value";
    DatagridView dvg=new DataGridView();
    dvg.Columns.Add(cmb);
    cmb.DataSource = dt;
    for (int i = 0; i < dvg.Rows.Count; i++)
    {
    dvg.Rows[i].Cells["ComboColumnSample"].Value = (cmb.Items[0] as 
    DataRowView).Row[1].ToString();
    }
               
