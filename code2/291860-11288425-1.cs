    private readonly ListViewSizeSorter _listViewSizeSorter;
            public Form1()
            {
                InitializeComponent();
                _listViewSizeSorter = new ListViewSizeSorter {SortColumn = 1};
            }
    
    private void ListViewFilesColumnClick(object sender, ColumnClickEventArgs e)
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == _listViewColumnSorter.SortColumn)
                {
                    if(e.Column.Equals(1))
                    {
                        listViewFiles.ListViewItemSorter = _listViewSizeSorter;
                        // Reverse the current sort direction for this column.
                        _listViewSizeSorter.Order = _listViewSizeSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    _listViewColumnSorter.SortColumn = e.Column;
                    _listViewColumnSorter.Order = SortOrder.Ascending;
                }
    
                // Perform the sort with these new sort options.
                listViewFiles.Sort();
            }
