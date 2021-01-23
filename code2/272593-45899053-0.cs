    private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
    	var ascending = true;
    
        gridView.DataSource = SortData(
            (List<MainGridViewModel>)gridReview.DataSource, gridReview.Columns[e.ColumnIndex].Name, ascending);
    }
    
    public List<MainGridViewModel> SortData(List<MainGridViewModel> list, string column, bool ascending)
    {
        return ascending ? 
            RefreshId(list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList()) :
            RefreshId(list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList());
    }
