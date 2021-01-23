     public ICollection CheckedItems
     {
        get
        {
            if (internalControl == null)
                return null;
            else
            {
                if (internalControl != null)
                {
                    if (internalControl.CheckedItems.Count > 0)
                    {
                        return internalControl.CheckedItems;
                    }
                    else
                    {
                        if ((CheckedListBox)this.DataGridView.Rows[RowIndex].Cells[ColumnIndex].DataGridView.EditingControl != null)
                        {
                            CheckedListBox checks = (CheckedListBox)this.DataGridView.Rows[RowIndex].Cells[ColumnIndex].DataGridView.EditingControl;
                            if (checks.CheckedItems.Count > 0)
                                return checks.CheckedItems;
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }  
