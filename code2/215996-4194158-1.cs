    private void dataGrid_SizeChanged(object sender, EventArgs e)
    {
        ResizeGridColumns();
    }
    private void ResizeGridColumns()
    {
        //get sum of non-resizable columns width
        int diffWidth = 0;
        foreach (DataGridViewColumn col in this.dataGrid.Columns)
        {
            if (col.Resizable == DataGridViewTriState.False && col.Visible) diffWidth += col.Width;
        }
        //calculate available width
        int totalResizableWith = this.dataGrid.Width - diffWidth;
        //resize column width based on previous proportions
        this.dataGrid.ColumnWidthChanged -= new DataGridViewColumnEventHandler(dataGrid_ColumnWidthChanged);
        for (int i = 0; i < this.colWidthRaport.Count; i++)
        {
            try
            {
                if (this.dataGrid.Columns[i].Resizable != DataGridViewTriState.False && this.dataGrid.Columns[i].Visible)
                {
                    this.dataGrid.Columns[i].Width = (int)Math.Floor((decimal)totalResizableWith / this.colWidthRaport[i]);
                }
            }
            catch { }
        }
        this.dataGrid.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGrid_ColumnWidthChanged);
    }
    private void dataGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
    {
        CalculateGridColWidthsRaport();
    }
    /// <summary>Calculates the proportions between grid width and column width</summary>
    private void CalculateGridColWidthsRaport()
    {
        //get sum of non-resizable columns width
        int diffWidth = 0;
        int colWidthsSum = 0;
        foreach (DataGridViewColumn col in this.dataGrid.Columns)
        {
            if (col.Visible)
            {
                colWidthsSum += col.Width;
                if (col.Resizable == DataGridViewTriState.False) diffWidth += col.Width;
            }
        }
        colWidthsSum += 24;
        //calculate available with
        int totalResizableWith = colWidthsSum - diffWidth;// this.dataGrid.Width - diffWidth;
        if (this.ParentForm.WindowState == FormWindowState.Maximized)
        {
            totalResizableWith = this.dataGrid.Width - diffWidth;
        }
        //calculate proportions of each column relative to the available width
        this.colWidthRaport = new List<decimal>();
        foreach (DataGridViewColumn col in this.dataGrid.Columns)
        {
            this.colWidthRaport.Add((decimal)totalResizableWith / (decimal)col.Width);
        }
    }
