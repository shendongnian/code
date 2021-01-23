    for (int i = 0; i < rowsCount; i++)
    {
         TableRow row = new TableRow();
         for (int j = 0; j < colsCount; j++)
         {
            TableCell cell = new TableCell();
            TextBox tb = new TextBox();
               tb.ID = "TextBoxRow_" + i + "Col_" + j;
               cell.Controls.Add(tb);
               row.Cells.Add(cell);
          }
         Table1.Rows.Add(row);
    }
    
