    private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        var g = (DataGridView)sender;
        var r = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
            g.RowHeadersWidth, e.RowBounds.Height);
        TextRenderer.DrawText(e.Graphics, $"{e.RowIndex + 1}",
            g.RowHeadersDefaultCellStyle.Font, r, g.RowHeadersDefaultCellStyle.ForeColor);
    }
