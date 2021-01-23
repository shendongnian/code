    private void datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            DataGridView dgv = (DataGridView)sender;
            if(dgv.CurrentCell.ColumnIndex==dgv.Columns["ColumnName"].Index) {
                ComboBox cbx = (ComboBox)e.Control;
                cbx.DropDownStyle = ComboBoxStyle.DropDown;
                cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }
