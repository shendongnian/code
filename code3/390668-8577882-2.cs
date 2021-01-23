        const int MandatoryColumnIndex = 1;
        public Form1()
		{
			InitializeComponent();
			dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
            dataGridView1.RowValidating += new DataGridViewCellCancelEventHandler(dataGridView1_RowValidating);
		}
	
		private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (dataGridView1.Rows[e.RowIndex].Cells[MandatoryColumnIndex].FormattedValue.ToString() == string.Empty)
			{
				e.Cancel = true;
				dataGridView1.Rows[e.RowIndex].Cells[MandatoryColumnIndex].ErrorText = "Mandatory";
			}
			else
			{
				dataGridView1.Rows[e.RowIndex].Cells[MandatoryColumnIndex].ErrorText = string.Empty;
			}
		}
		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
		    if (e.ColumnIndex == MandatoryColumnIndex)
			{
				if (e.FormattedValue.ToString() == string.Empty)
				{
					dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = "Mandatory";
					e.Cancel = true;
				}
				else
				{
					dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
				}			
            }
		}
