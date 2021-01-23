    private void Daywisegrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.RowIndex == 0 )
    
                {
                    using (Brush gridBrush = new SolidBrush(this.Daywisegrid.GridColor))
                    {
                        using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        {
                            using (Pen gridLinePen = new Pen(gridBrush))
                            {
                                // Clear cell 
                                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                                //Bottom line drawing
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom-1 , e.CellBounds.Right, e.CellBounds.Bottom-1);
    
                                  // here you force paint of content
                                 e.PaintContent( e.ClipBounds  );
                                e.Handled = true;
                            }
                        }
                    }
                }
