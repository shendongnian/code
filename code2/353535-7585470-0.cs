    public void AutoSizeCol(int col)
    {
         float width = 0;
         int numRows = ((DataTable)dataGrid1.DataSource).Rows.Count;
              
         using (Graphics g = Graphics.FromHwnd(dataGrid1.Handle))
         {
             StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
             SizeF size;
    
             for(int i = 0; i < numRows; i++)
             {
                 size = g.MeasureString(dataGrid1[i, col].ToString(), dataGrid1.Font, 500, sf);
                 if(size.Width > width)
                 {
                     width = size.Width;
                 }
             }    
         }
    
         dataGrid1.TableStyles["customers"].GridColumnStyles[col].Width = (int) width + 8;
    }
