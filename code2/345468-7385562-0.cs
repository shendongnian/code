    private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
        if (String.IsNullOrEmpty(dataGridView.CurrentCell.Value.ToString())) {
	        // Display error string in cell
	        dataGridView.CurrentCell.Value = "No Value";
	        // Set color to red
	        dataGridView.CurrentCell.Style.ForeColor = System.Drawing.Color.Red;
	    }
    }
