	using System.Linq.Dynamic;
	private bool sortAscending = false;
	private void dataGridView_ColumnHeaderMouseClick ( object sender, DataGridViewCellMouseEventArgs e )
	{
		if ( sortAscending )
			dataGridView.DataSource = list.OrderBy ( dataGridView.Columns [ e.ColumnIndex ].DataPropertyName ).ToList ( );
		else
			dataGridView.DataSource = list.OrderBy ( dataGridView.Columns [ e.ColumnIndex ].DataPropertyName ).Reverse ( ).ToList ( );
		sortAscending = !sortAscending;
	}
