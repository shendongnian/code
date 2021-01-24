    public void TrackChanges(object o, DataGridViewCellEventArgs args)
    {
        int col = args.ColumnIndex;
        int row = args.RowIndex;
        DataGridView source = o as DataGridView;
        object newValue = source[col, row].Value;
        Console.WriteLine("Value '{0}' in row {1} and column {2} of DataGridView {3} changed!", newValue, row, col, source.Name);
    }
