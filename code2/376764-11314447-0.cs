    private void grdCons_DragDrop(object sender, DragEventArgs e)
    {
        DataTable tbl = (DataTable)grdCons.DataSource;
        Point clientPoint = grdCons.PointToClient(new Point(e.X, e.Y));
        int targetIndex = grdCons.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
    
        if (e.Effect == DragDropEffects.Move)
        {
            DataRow row = tbl.NewRow();
            row.ItemArray = tbl.Rows[rowIndexFromMouseDown].ItemArray; //copy the elements
            tbl.Rows.RemoveAt(rowIndexFromMouseDown);
            tbl.Rows.Insert(targetIndex, rowToMove);
        }
    }
