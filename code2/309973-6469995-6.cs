		private void myDataGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			DependencyObject dep = (DependencyObject)e.OriginalSource;
			while ((dep != null) &&
			!(dep is DataGridCell) &&
			!(dep is DataGridColumnHeader))
			{
				dep = VisualTreeHelper.GetParent(dep);
			}
			if (dep == null)
				return;
			if (dep is DataGridColumnHeader)
			{
				DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
				// check if this is the wanted column
				if (columnHeader.Column.Header.ToString() == "The_Wanted_Column_Title")
				{
					System.Windows.Data.CollectionViewSource myViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myViewSource")));
					myViewSource.SortDescriptions.Clear();
					myViewSource.SortDescriptions.Add(new SortDescription("Column1", ListSortDirection.Ascending));
					myViewSource.SortDescriptions.Add(new SortDescription("Column2", ListSortDirection.Ascending));
				}
				else
				{
					//usort the grid on clicking on any other columns, or maybe do another sort combination
					System.Windows.Data.CollectionViewSource myViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("myViewSource")));
					myViewSource.SortDescriptions.Clear();
				}
			}
		}
	
