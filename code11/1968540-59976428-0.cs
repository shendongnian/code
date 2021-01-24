    int topIndex = 0, leftIndex = 0;
    int originalLeftIndex = 0, originalTopIndex = 0;
    int cellSize = 100;
    Point p1;
    TableLayoutPanel panel;
    void LayoutGrid()
    {
        panel.SuspendLayout();
        var columns = (ClientSize.Width / cellSize) + 1;
        var rows = (ClientSize.Height / cellSize) + 1;
        panel.RowCount = rows;
        panel.ColumnCount = columns;
        panel.ColumnStyles.Clear();
        panel.RowStyles.Clear();
        for (int i = 0; i < columns; i++)
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));
        for (int i = 0; i < rows; i++)
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
        panel.Width = columns * cellSize;
        panel.Height = rows * cellSize;
        panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        panel.ResumeLayout();
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        panel = new MyGrid();
        this.Controls.Add(panel);
        LayoutGrid();
        panel.MouseDown += Panel_MouseDown;
        panel.MouseMove += Panel_MouseMove;
        panel.CellPaint += Panel_CellPaint;
    }
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        if (panel != null)
            LayoutGrid();
    }
    private void Panel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        var g = e.Graphics;
        TextRenderer.DrawText(g, $"({e.Column + leftIndex}, {e.Row + topIndex})",
            panel.Font, e.CellBounds, panel.ForeColor);
    }
    private void Panel_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            var dx = (e.Location.X - p1.X) / cellSize;
            var dy = (e.Location.Y - p1.Y) / cellSize;
            leftIndex = originalLeftIndex - dx;
            topIndex = originalTopIndex - dy;
            panel.Invalidate();
        }
    }
    private void Panel_MouseDown(object sender, MouseEventArgs e)
    {
        p1 = e.Location;
        originalLeftIndex = leftIndex;
        originalTopIndex = topIndex;
    }
