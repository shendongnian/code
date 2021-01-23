    void gvTransaction_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (gvTransaction.IsCurrentCellDirty)
        {
            gvTransaction.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
