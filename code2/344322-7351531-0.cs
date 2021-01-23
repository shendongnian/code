    HtmlTable table = new HtmlTable();
    HtmlTableRow row;
    HtmlTableCell cell;
    
    for(int x = 0; x < userList.Count; x++)
    {
    			if(x%3 == 0)
    			{
    				row = new HtmlTableRow();
    				table.Controls.Add(row);
    			}
       cell = new HtmlTableCell();
       row.Controls.Add(cell);
    }
    
    for(int x = 0; x < userList.Count%3; x++)
    {
       cell = new HtmlTableCell();
       row.Controls.Add(cell);
    }
