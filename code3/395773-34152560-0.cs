    //C# version for buttons also. Inspired by sveilleux2.
    private void DataGridView1_EnabledChanged(object sender, EventArgs e){
	if (!DataGridView1.Enabled){
		DataGridView1.DefaultCellStyle.BackColor = SystemColors.Control;
		DataGridView1.DefaultCellStyle.ForeColor = SystemColors.GrayText;
		DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
		DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
		//Disable two colums of buttons
		for (int i = 0; i < DataGridView1.RowCount; i++){
			DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)DataGridView1.Rows[i].Cells[1];
			buttonCell.FlatStyle = FlatStyle.Popup;
			buttonCell.Style.ForeColor = SystemColors.GrayText;
			buttonCell.Style.BackColor = SystemColors.Control;
			DataGridViewButtonCell buttonCell_2 = (DataGridViewButtonCell)DataGridView1.Rows[i].Cells[6];
			buttonCell_2.FlatStyle = FlatStyle.Popup;
			buttonCell_2.Style.ForeColor = SystemColors.GrayText;
			buttonCell_2.Style.BackColor = SystemColors.Control;
		}
		DataGridView1.Columns[1].DefaultCellStyle.ForeColor = SystemColors.GrayText;
		DataGridView1.Columns[1].DefaultCellStyle.BackColor = SystemColors.Control;
		DataGridView1.ReadOnly = true;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.CurrentCell = null;
	}else{
		DataGridView1.DefaultCellStyle.BackColor = SystemColors.Window;
		DataGridView1.DefaultCellStyle.ForeColor = SystemColors.ControlText;
		DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
		DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
		DataGridView1.ReadOnly = false;
		DataGridView1.EnableHeadersVisualStyles = false;
		//Enable two colums of buttons
		for (int i = 0; i < DataGridView1.RowCount; i++){
			DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)DataGridView1.Rows[i].Cells[1];
			buttonCell.FlatStyle = FlatStyle.Standard;
			DataGridViewButtonCell buttonCell_2 = (DataGridViewButtonCell)DataGridView1.Rows[i].Cells[6];
			buttonCell_2.FlatStyle = FlatStyle.Standard;
		}
	}
}
