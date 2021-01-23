        const int MandatoryColumnIndex = 1;
        public Form1()
		{
			InitializeComponent();
			dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
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
