      private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
            {
                // get the row number in leading zero format, 
                //  where the width of the number = the width of the maximum number
                int RowNumWidth = dataGridView1.RowCount.ToString().Length;
                StringBuilder RowNumber = new StringBuilder(RowNumWidth);
                RowNumber.Append(e.RowIndex + 1);
                while (RowNumber.Length < RowNumWidth)
                    RowNumber.Insert(0, "0");
    
                // get the size of the row number string
                SizeF Sz = e.Graphics.MeasureString(RowNumber.ToString(), this.Font);
    
                // adjust the width of the column that contains the row header cells 
                if (dataGridView1.RowHeadersWidth < (int)(Sz.Width + 20))
                    dataGridView1.RowHeadersWidth = (int)(Sz.Width + 20);
    
                // draw the row number
                   e.Graphics.DrawString(
                    RowNumber.ToString(), 
                    this.Font, 
                    SystemBrushes.ControlText, 
                    e.RowBounds.Location.X + 15, 
                    e.RowBounds.Location.Y + ((e.RowBounds.Height - Sz.Height) / 2));
            }
