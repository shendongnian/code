    public static void GetDataGridViewUIInfo(this DataGridView dgv, out List<int> selectedIndices,
      out int? sortColumnIndex, out ListSortDirection sortOrder)
    {
      selectedIndices = dgv.GetSelectedRowIndices();
      dgv.GetSortInfo(out sortColumnIndex, out sortOrder);
    }
    
    static List<int> GetSelectedRowIndices(this DataGridView dgv)
    {
      List<int> selectedIndices = new List<int>();
    
      foreach (DataGridViewRow row in dgv.SelectedRows)
      {
        selectedIndices.Add(row.Index);
      }
        
      return selectedIndices;
    }
    
    static void GetSortInfo(this DataGridView dgv, out int? sortColumnIndex, out ListSortDirection sortOrder)
    {
      // Store the sort details
      switch (dgv.SortOrder)
      {
        case SortOrder.Ascending:
          sortOrder = ListSortDirection.Ascending;
          break;
        case SortOrder.Descending:
          sortOrder = ListSortDirection.Descending;
          break;
        default:
          sortOrder = ListSortDirection.Ascending;
          break;
      }
        
      sortColumnIndex = dgv.SortedColumn == null ? null : (int?)dgv.SortedColumn.Index;
    }
        
