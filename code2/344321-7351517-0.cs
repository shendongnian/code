    HtmlTable table = new HtmlTable();
    HtmlTableRow row;
    HtmlTableCell cell;
    for(int x = 0; x < userList.Count; x++)
    {
    row = HtmlTableRow();
    cell = HtmlTableCell();
    // other stuff
     row.Controls.Add(cell);
     if((x+1) % 3 == 0)
    {
     table.Controls.Add(row);
    }
    }
