    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DevExpress.XtraGrid.Views.Grid;
    
    namespace Extensions
    {
        public static class XtraGridExtensions
        {
            public static IEnumerable<string> GetColumnsDistinctDisplayText(this GridView gv, string columnName)
            {
                if (gv == null)
                {
                    throw new NullReferenceException("GridView is null");
                }
                return (from int row in Enumerable.Range(0, gv.RowCount - 1)
                        select gv.GetRowCellDisplayText(row, columnName)).Distinct().OrderBy(s => s);
            }
        }
    }
