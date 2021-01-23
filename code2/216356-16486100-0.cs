    private void DGV_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DGV.ClearSelection();
            DGV.Rows[e.RowIndex].Selected = true;
            e.ContextMenuStrip = MENUSTRIP;
        }
    }
