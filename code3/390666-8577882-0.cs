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
					e.Cancel = true;
				}
			}
		}
