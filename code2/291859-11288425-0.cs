    using System.Collections;
    using System.Windows.Forms;
    
    namespace MyNameSpace
    {
        /// <summary>
        /// This class is an implementation of the 'IComparer' interface.
        /// </summary>
        public class ListViewSizeSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int _columnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder _orderOfSort;
    
            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewSizeSorter()
            {
                // Initialize the column to '0'
                SortColumn = 0;
    
                // Initialize the sort order to 'none'
                Order = SortOrder.None;
            }
    
            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                var listviewX = (ListViewItem)x;
                var listviewY = (ListViewItem)y;
                string strX = listviewX.SubItems[_columnToSort].Text;
                string strY = listviewY.SubItems[_columnToSort].Text;
    
                // Nulls first (null means less, since it's blank)
                if (strX == null)
                {
                    if (strY == null)
                        return 0;
                    return -1;
                }
                if (strY == null)
                    return 1;
    
                // Convert the non-KB part to a number
                double numX = 0;
                double numY = 0;
                if (strX.EndsWith("KB") || strX.EndsWith("GB") || strX.EndsWith("MB"))
                    double.TryParse(strX.Substring(0, strX.Length - 3), out numX);
                if (strX.EndsWith("Bytes"))
                    double.TryParse(strX.Substring(0, strX.Length - 6), out numX);
                if (strY.EndsWith("KB") || strY.EndsWith("GB") || strY.EndsWith("MB"))
                    double.TryParse(strY.Substring(0, strY.Length - 3), out numY);
                if (strY.EndsWith("Bytes"))
                    double.TryParse(strX.Substring(0, strY.Length - 6), out numY);
                long bytesX;
                long bytesY;
                if (strX.EndsWith("KB"))
                    bytesX = (long)numX * 1024;
                else if (strX.EndsWith("MB"))
                    bytesX = (long)numX * 1048576;
                else if (strX.EndsWith("GB"))
                    bytesX = (long)numX * 1073741824;
                else
                    bytesX = (long) numX;
    
                if (strY.EndsWith("KB"))
                    bytesY = (long)numY * 1024;
                else if (strY.EndsWith("MB"))
                    bytesY = (long)numY * 1048576;
                else if (strY.EndsWith("GB"))
                    bytesY = (long)numY * 1073741824;
                else
                    bytesY = (long) numY;
    
                var compareResult = bytesX.CompareTo(bytesY);
    
                if (_orderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                if (_orderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                // Return '0' to indicate they are equal
                return 0;
            }
    
            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    _columnToSort = value;
                }
                get
                {
                    return _columnToSort;
                }
            }
    
            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    _orderOfSort = value;
                }
                get
                {
                    return _orderOfSort;
                }
            }
        }
    }
