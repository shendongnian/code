    new Binding("DataContext.ToolTipSorting")
			{
				RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor)
				{
					AncestorType = typeof(DataGrid)
				}
			}
