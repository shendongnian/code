    private int _previousIndex;
    private bool _sortDirection;
    
    private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    	if (e.ColumnIndex == _previousIndex)
            _sortDirection ^= true; // toggle direction
    
        gridView.DataSource = SortData(
            (List<MainGridViewModel>)gridReview.DataSource, gridReview.Columns[e.ColumnIndex].Name, _sortDirection);
    
        _previousIndex = e.ColumnIndex;
    }
    
    public List<MainGridViewModel> SortData(List<MainGridViewModel> list, string column, bool ascending)
    {
        return ascending ? 
            list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
            list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
    }
