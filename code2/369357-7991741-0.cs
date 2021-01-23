		private void listviewname_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			e.Cancel = true;
			e.NewWidth = listviewname.Columns[e.ColumnIndex].Width;
		}
