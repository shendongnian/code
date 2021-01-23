    private void DataGridViewXYZ_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
    {
                    if (e.Cell == null
                        || e.StateChanged != DataGridViewElementStates.Selected)
                        return;
                    if (! [condition here : can this cell be selectable ?])
                        e.Cell.Selected = false;
    }
