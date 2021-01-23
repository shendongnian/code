    private DragGrid(DataTable table)
    {
        this.DataSource = table;
        this.DragEnter += new EventHandler<DragEventArgs>(_onDragEnter);
    }
    private void _onDragEnter(object sender, DragEventArgs e)
    {
        // your code here
    }
