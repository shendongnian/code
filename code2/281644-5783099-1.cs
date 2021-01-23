    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        // check that we are in a header cell!
        if (e.RowIndex == -1 && e.ColumnIndex >= 0)
        {
            e.PaintBackground(e.ClipBounds, true);
            Rectangle rect = this.dataGridView1.GetColumnDisplayRectangle(e.ColumnIndex, true);
            Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
            if (this.dataGridView1.ColumnHeadersHeight < titleSize.Width)
                this.dataGridView1.ColumnHeadersHeight = titleSize.Width;
            e.Graphics.TranslateTransform(0, titleSize.Width);
            e.Graphics.RotateTransform(-90.0F);
               
            e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));
            e.Graphics.RotateTransform(90.0F);
            e.Graphics.TranslateTransform(0, -titleSize.Width);
            e.Handled = true;
        }
    }
