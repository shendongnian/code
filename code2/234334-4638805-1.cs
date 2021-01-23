    public class ListViewItemComparer : IComparer
    {
        // Specifies the column to be sorted
        private int ColumnToSort;
        // Specifies the order in which to sort (i.e. 'Ascending').
        private  SortOrder OrderOfSort;
        // Case insensitive comparer object
        private CaseInsensitiveComparer ObjectCompare;
        // Class constructor, initializes various elements
        public ListViewItemComparer()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;
            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;
            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }
        // This method is inherited from the IComparer interface.
        // It compares the two objects passed using a case
        // insensitive comparison.
        //
        // x: First object to be compared
        // y: Second object to be compared
        //
        // The result of the comparison. "0" if equal,
        // negative if 'x' is less than 'y' and
        // positive if 'x' is greater than 'y'
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                DateTime firstDate  = DateTime.Parse(listviewX.SubItems[ColumnToSort].Text);
                DateTime secondDate = DateTime.Parse(listviewY.SubItems[ColumnToSort].Text);
                // Compare the two dates.
                compareResult = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format,
            // perform a Case Insensitive Sort
            catch
            {
                try
                {
                    int num1 = int.Parse(listviewX.SubItems[ColumnToSort].Text);
                    int num2 = int.Parse(listviewY.SubItems[ColumnToSort].Text);
                    // Compare the two dates.
                    compareResult = num1.CompareTo(num2);
                }
                catch
                {
                   // Case Insensitive Compare
                    compareResult = ObjectCompare.Compare(
                    listviewX.SubItems[ColumnToSort].Text,
                    listviewY.SubItems[ColumnToSort].Text
                    );
                }
            }
            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }  
        // Gets or sets the number of the column to which to
        // apply the sorting operation (Defaults to '0').
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        // Gets or sets the order of sorting to apply
        // (for example, 'Ascending' or 'Descending').
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    } 
