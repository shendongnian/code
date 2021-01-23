        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                CustomRightToLeftColumnNames.Contains(this.Columns[e.ColumnIndex].Name))
            {
                // Method 2:
                e.PaintBackground(e.CellBounds, true);
                if (e.FormattedValue != null)
                {
                    TextFormatFlags flags = TextFormatFlags.RightToLeft         |
                                            TextFormatFlags.VerticalCenter      |
                                            TextFormatFlags.Right               |
                                            TextFormatFlags.LeftAndRightPadding;// |
                                            //TextFormatFlags.EndEllipsis;
                    TextRenderer.DrawText
                    (
                        e.Graphics,
                        e.FormattedValue.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        e.CellStyle.ForeColor,
                        flags
                    );
                }
                e.Handled = true;
            }
        }
