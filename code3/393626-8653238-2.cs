    void grd_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (grd.IsCurrentCellDirty)
        {
            grd.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
