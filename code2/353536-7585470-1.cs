    public void AutoSizeCol(int col)
    {
         float width = 0;
              
         using (Graphics graphics = Graphics.FromHwnd(DataGrid1.Handle))
         {
             StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
    
             for(int rowIndex = 0; rowIndex < ((DataTable)DataGrid1.DataSource).Items.Count; rowIndex++)
             {
                 SizeF size = graphics.MeasureString(DataGrid1.Items[rowIndex].Cells[col].Text, DataGrid1.ItemStyle.Font, 500, sf);
                 if(size.Width > width)
                 {
                     width = size.Width;
                 }
             }    
         }
    
         DataGrid1.TableStyles["customers"].GridColumnStyles[col].Width = (int)width + 8;
    }
