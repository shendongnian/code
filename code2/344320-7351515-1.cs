    row = HtmlTableRow();
    int cellCount = 0;
    for(int x = 0; x < userList.Count; x++)
    {
       cell = HtmlTableCell();
    
       // other stuff
    
       row.Controls.Add(cell);
    
       cellCount++;
       
       if(cellCount == 3)
       {
          cellCount = 0;
          table.Controls.Add(row);
          row = HtmlTableRow();
       }
    }
