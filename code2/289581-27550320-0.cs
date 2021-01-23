	uint VisibleRows = 0;
	var TicketGrid = (DataGrid) MyWindow.FindName("TicketGrid");
	foreach(var Item in TicketGrid.Items) {
		var Row = (DataGridRow) TicketGrid.ItemContainerGenerator.ContainerFromItem(Item);
		if(Row != null) {
			if(Row.TransformToVisual(TicketGrid).Transform(new Point(0, 0)).Y + Row.ActualHeight >= TicketGrid.ActualHeight) {
				break;
			}
			VisibleRows++;
		}
	}
