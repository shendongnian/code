    private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
        if (e.RowIndex == -1 && dgv.Columns[e.ColumnIndex].HeaderText == "March Sale ($)") {
            //draw non-content portion
            e.Paint(e.CellBounds, e.PaintParts ^ DataGridViewPaintParts.ContentForeground);
            //get size of text to write
            SizeF firstTextSize = e.Graphics.MeasureString("March Sale ", e.CellStyle.Font);
            SizeF secondTextSize = e.Graphics.MeasureString("($)",  new Font(e.CellStyle.Font, FontStyle.Bold));
            Point p = e.CellBounds.Location;
            //center text
            p.Offset((int)((e.CellBounds.Width-firstTextSize.Width-secondTextSize.Width)/2), (int)((e.CellBounds.Height-firstTextSize.Height)/2));
            e.Graphics.DrawString("March Sale ", e.CellStyle.Font, new SolidBrush(Color.Black), p);
            p.Offset((int)firstTextSize.Width,0);
            e.Graphics.DrawString("($)", new Font(e.CellStyle.Font, FontStyle.Bold), new SolidBrush(Color.Red), p);
            e.Handled = true;
        }
    }
