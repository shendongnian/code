    private void dataGrid1_DoubleClick(object sender, EventArgs e)
    {
        Point pt = dataGrid1.PointToClient(Control.MousePosition);
        DataGrid.HitTestInfo info = dataGrid1.HitTest(pt.X, pt.Y);
        int row;
        int col;
        if (info.Column < 0)
            col = 0;
        else
            col = info.Column;
        if (info.Row < 0)
            row = 0;
        else
            row = info.Row;
        object cellData = dataGrid1[row, col];
        string cellString = "(null)";
        if (cellData != null)
            cellString = cellData.ToString();
        MessageBox.Show(cellString, "Cell Contents");
    }
