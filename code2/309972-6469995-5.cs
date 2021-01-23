		private void btnSort_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Data.CollectionViewSource myViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("The_ViewSource_Name")));
			myViewSource.SortDescriptions.Add(new SortDescription("Column1", ListSortDirection.Ascending));
			myViewSource.SortDescriptions.Add(new SortDescription("Column2", ListSortDirection.Ascending));
		}
