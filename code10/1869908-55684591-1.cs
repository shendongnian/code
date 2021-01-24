    private void dgvTable_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e) // Handles dgvTable.EditingControlShowing
    {
        TextBox tbx = (TextBox)e.Control;
        string cn = dgvTable.Columns(dgvTable.CurrentCell.ColumnIndex).Name;
        if (cn == "Column1")
        {
            AutoCompleteStringCollection acs = new AutoCompleteStringCollection();
            foreach (DataRow dRow in dt.Rows)
                acs.Add(dRow("Column1").ToString);
            tbx.AutoCompleteCustomSource = acs;
            tbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }
    class myDgv : DataGridView
    {
        protected override bool ProcessDataGridViewKey(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else
                return base.ProcessDataGridViewKey(e);
        }
    }
