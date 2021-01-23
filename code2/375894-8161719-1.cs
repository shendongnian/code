    var groupedRows = from row in dtTable.Rows.AsEnumerable()
    				  group row by row[0] into grouped
    				  select grouped;
    				  
    foreach (var group in groupedRows)
    {
    	currentPane = new AccordionPane();
    	currentPane.HeaderContainer.Controls.Add(group.Key.ToString());
    	
    	foreach (var row in group)
    	{
    		currentPane.ContentContainer.Controls.Add(row[1].ToString());
    	}	
    }
