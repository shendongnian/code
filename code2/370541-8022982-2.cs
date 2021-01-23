    public System.Windows.Forms.DataGridView GetDataGridView(string columnName)
    {
    	var dgv = new System.Windows.Forms.DataGridView();
    	var column = new System.Windows.Forms.DataGridViewTextBoxColumn();
    	column.DataPropertyName = columnName;
    	column.Name = columnName;
    	dgv.Columns.Add(column);
    	dgv.Rows.Add("-cat--dog----");
    	dgv.Rows.Add("--elephant----mouse----");
    	return dgv;
    }
