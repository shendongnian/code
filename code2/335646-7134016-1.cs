        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex ==  -1)
            {
                using (Brush gridBrush = new SolidBrush(this.Daywisegrid.GridColor))
                {
                    using (Brush backColorBrush = new SolidBrush(Color.Red))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            // Clear cell 
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                            //Bottom line drawing
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom-1 , e.CellBounds.Right, e.CellBounds.Bottom-1);
                            e.Handled = true;
                        }
                    }
                }
            }
