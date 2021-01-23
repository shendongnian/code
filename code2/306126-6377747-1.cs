	private void dataGridView_DoubleClick(object sender, EventArgs e)
	{  
		var grid = (DataGridView)sender;
		var point = grid.PointToClient(Cursor.Position);
		var hit = grid.HitTest(p.X, p.Y);      
		MessageBox.Show(string.Format("{0} / {1}", hit.ColumnIndex, hit.RowIndex));
	}
