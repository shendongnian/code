    public static void SetDataGridViewUIInfo(this DataGridView dgv, List<int> selectedIndices,
      int? sortColumnIndex, ListSortDirection sortOrder)
    {
      dgv.SetSelectedRowIndices(selectedIndices);
      dgv.SetSortInfo(sortColumnIndex, sortOrder);
    }
    
    static void SetSelectedRowIndices(this DataGridView dgv, List<int> selectedIndices)
    {
      if (dgv.Rows.Count <= 0)
        // Early out if there is no row in the data grid view
        return;
    
      foreach (DataGridViewRow row in dgv.Rows)
      {
        row.Selected = false;
      }
    
      foreach (int index in selectedIndices)
      {
        if (index < dgv.Rows.Count)
          dgv.Rows[index].Selected = true;
        else
          dgv.Rows[dgv.Rows.Count - 1].Selected = true;
      }
    
      if (selectedIndices.Count > 0 && selectedIndices[0] < dgv.Rows.Count && dgv.DataSource is BindingSource)
        ((BindingSource)dgv.DataSource).Position = selectedIndices[0];
    }
    
    static void SetSortInfo(this DataGridView dgv, int? sortColumnIndex, ListSortDirection sortOrder)
    {
      if (sortColumnIndex == null)
        // Early out if there was no column used to sort in the data grid view
        return;
    
      // Restore the sort details
      dgv.Sort(dgv.Columns[(int)sortColumnIndex], sortOrder);
    }
