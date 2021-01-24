    private class RowComparer : System.Collections.IComparer
    {
        private static int sortOrderModifier = 1;
    
        public RowComparer(ListSortDirection sortOrder)
        {
            if (sortOrder == ListSortDirection.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == ListSortDirection.Ascending)
            {
                sortOrderModifier = 1;
            }
        }
    
        public int Compare(object x, object y)
        {
            var DataGridViewRow1 = (DataGridViewRow)x;
            var DataGridViewRow2 = (DataGridViewRow)y;
    
            // Try to sort based on the Last Name column.
            int CompareResult = int.Parse(
                DataGridViewRow1.Cells[2].Value.ToString()
                ).CompareTo(int.Parse(
                DataGridViewRow2.Cells[2].Value.ToString()));       
            return CompareResult * sortOrderModifier;
        }
    }
