    Point currentPointerLocation = Point.Empty;
    Rectangle currentCellBounds = Rectangle.Empty;
    Point currentCell = Point.Empty;
    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        if (e.CellBounds.Contains(currentPointerLocation)) {
            currentCellBounds = e.CellBounds;
            currentCell = new Point(e.Row, e.Column);
            e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
        }
        else {
            using (var brush = new SolidBrush(tableLayoutPanel1.BackColor)) {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }
    private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
    {
        currentPointerLocation = e.Location;
        this.tableLayoutPanel1.Invalidate();
        this.tableLayoutPanel1.Update();
        lblCurrentCell.Text = currentCell.ToString();
        lblCellBounds.Text = currentCellBounds.ToString();
    }
