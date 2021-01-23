    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace DataGridView2
    {
       
        class DataGridView2 : DataGridView
        {
            
            protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
            {
                base.OnRowPostPaint(e);
    
                // get the row number in leading zero format, 
                //  where the width of the number = the width of the maximum number
                int RowNumWidth = this.RowCount.ToString().Length;
                StringBuilder RowNumber = new StringBuilder(RowNumWidth);
                RowNumber.Append(e.RowIndex + 1);
                while (RowNumber.Length < RowNumWidth)
                    RowNumber.Insert(0, "0");
    
                // get the size of the row number string
                SizeF Sz = e.Graphics.MeasureString(RowNumber.ToString(), this.Font);
    
                // adjust the width of the column that contains the row header cells 
                if (this.RowHeadersWidth < (int)(Sz.Width + 20)) 
                    this.RowHeadersWidth = (int)(Sz.Width + 20);
    
                // draw the row number
                e.Graphics.DrawString(
                    RowNumber.ToString(), 
                    this.Font, 
                    SystemBrushes.ControlText, 
                    e.RowBounds.Location.X + 15, 
                    e.RowBounds.Location.Y + ((e.RowBounds.Height - Sz.Height) / 2));
            } 
        }
    } 
