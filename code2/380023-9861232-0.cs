    TreeItemCellRenderer cellRenderer = new TreeItemCellRenderer();
    column.SetCellDataFunc(cellRenderer, new Gtk.TreeCellDataFunc(AwesomeDataFunction));
    
    /**
    * Supplies the TreeItemCellRenderer with data for the current cell.
    * */
    private void AwesomeDataFunction(Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
	{
		(cell as TreeItemCellRenderer).<some self-declared property> = <any fitting value>;
	}
