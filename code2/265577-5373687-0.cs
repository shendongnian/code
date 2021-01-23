    private void dgv_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
    {
	if (e.Control is DataGridViewComboBoxEditingControl) {
		DataGridViewComboBoxEditingControl control = e.Control as DataGridViewComboBoxEditingControl;
		BindingSource bs = control.DataSource as BindingSource;
		if (!IsNothing(bs)) {
			// set the filteredChildBS as the DataSource of the editing control
			TryCast(e.Control as ComboBox).DataSource = filteredChildBS;
			//Set the dgv's combobox to the first item
			TryCast(e.Control, ComboBox).SelectedIndex = 1
		}
	}
