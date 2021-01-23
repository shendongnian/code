    private void dgv_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
    {
	if (e.Control is DataGridViewComboBoxEditingControl) {
		DataGridViewComboBoxEditingControl control = e.Control as DataGridViewComboBoxEditingControl;
		BindingSource bs = control.DataSource as BindingSource;
		if (!IsNothing(bs)) {
			// set the filteredChildBS as the DataSource of the editing control
			 ((ComboBox)e.Control).DataSource = filteredChildBS;
			//Set the dgv's combobox to the first item
			 ((ComboBox)e.Control).SelectedIndex = 1
		}
	}
