		IDataGridViewEditingControl _iDataGridViewEditingControl;
		private void SlotTimesDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (_iDataGridViewEditingControl is DataGridViewComboBoxEditingControl)
			{
				DataGridViewComboBoxEditingControl iDataGridViewEditingControl = _iDataGridViewEditingControl as DataGridViewComboBoxEditingControl;
				iDataGridViewEditingControl.KeyPress -= SlotTimesDGV_EditingControlShowing_KeyPress;
			}
			if (e.Control is DataGridViewComboBoxEditingControl)
			{
				DataGridViewComboBoxEditingControl iDataGridViewEditingControl = e.Control as DataGridViewComboBoxEditingControl;
				iDataGridViewEditingControl.KeyPress += SlotTimesDGV_EditingControlShowing_KeyPress;
				_iDataGridViewEditingControl = iDataGridViewEditingControl;
			}
		}
		private void SlotTimesDGV_EditingControlShowing_KeyPress(object sender, KeyPressEventArgs e)
		{
			MessageBox.Show("");
		}
