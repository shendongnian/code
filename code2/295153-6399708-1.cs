    public void MatchCurrencyManagerPosition(bool scrollIntoView, bool clearSelection)
    {
        if (this.owner.Columns.Count != 0)
        {
            int columnIndex = (this.owner.CurrentCellAddress.X == -1) ? this.owner.FirstDisplayedColumnIndex : this.owner.CurrentCellAddress.X;
            if (columnIndex == -1)
            {
                DataGridViewColumn firstColumn = this.owner.Columns.GetFirstColumn(DataGridViewElementStates.None);
                firstColumn.Visible = true;
                columnIndex = firstColumn.Index;
            }
            int position = this.currencyManager.Position;
            if (position == -1)
            {
                if (!this.owner.SetCurrentCellAddressCore(-1, -1, false, false, false))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
                }
            }
            else if (position < this.owner.Rows.Count)
            {
                if ((this.owner.Rows.GetRowState(position) & DataGridViewElementStates.Visible) == DataGridViewElementStates.None)
                {
                    this.owner.Rows[position].Visible = true;
                }
                if (((position != this.owner.CurrentCellAddress.Y) || (columnIndex != this.owner.CurrentCellAddress.X)) && ((scrollIntoView && !this.owner.ScrollIntoView(columnIndex, position, true)) || (((columnIndex < this.owner.Columns.Count) && (position < this.owner.Rows.Count)) && !this.owner.SetAndSelectCurrentCellAddress(columnIndex, position, true, false, false, clearSelection, false))))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
                }
            }
        }
    }
