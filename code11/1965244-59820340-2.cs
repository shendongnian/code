     if (e.ColumnIndex == yourGrid.Columns["Accept"].Index)
     {
          e.Paint(e.CellBounds, DataGridViewPaintParts.All);
          var w = Properties.Resources.yes.Width;
          var h = Properties.Resources.yes.Height;
          var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
          var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
          e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
     } //if
