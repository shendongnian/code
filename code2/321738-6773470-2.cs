    public static class Utility
    {
        /// <summary>
        /// Gets the ordinal index of a TableCell in a rendered GridViewRow, using a text fieldHandle (e.g. the corresponding column's DataFieldName/SortExpression/HeaderText)
        /// </summary>
        public static int GetCellIndexByFieldHandle(this GridView grid, string fieldHandle)
        {
            int iCellIndex = -1;
            for (int iColIndex = 0; iColIndex < grid.Columns.Count; iColIndex++)
            {
                if (grid.Columns[iColIndex] is DataControlField)
                {
                    DataControlField col = (DataControlField)grid.Columns[iColIndex];
                    if ((col is BoundField && string.Compare(((BoundField)col).DataField, fieldHandle, true) == 0)
                        || string.Compare(col.SortExpression, fieldHandle, true) == 0
                        || col.HeaderText.Contains(fieldHandle))
                    {
                        iCellIndex = iColIndex;
                        break;
                    }
                }
            }
            return iCellIndex;
        }
        /// <summary>
        /// Gets the ordinal index of a TableCell in a rendered GridViewRow, using a text fieldHandle (e.g. the corresponding column's DataFieldName/SortExpression/HeaderText)
        /// </summary>
        public static int GetCellIndexByFieldHandle(this GridViewRow row, string fieldHandle)
        {
            return GetCellIndexByFieldHandle((GridView)row.Parent.Parent, fieldHandle);
        }
    }
