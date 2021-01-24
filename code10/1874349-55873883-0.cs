    protected void MyTable_DataBound(object sender, EventArgs e)
    {
    	Boolean hasData = false;
    	for (int col = 0; col < MyTable.HeaderRow.Cells.Count; col++)
    	{
    		if (MyTable.Columns[col] is HyperLinkField || MyTable.Columns[col] is TemplateField)
    		{
    			continue;
    		}
    	
    		for (int row = 0; row < MyTable.Rows.Count; row++)
    		{
    			if(!String.IsNullOrEmpty(MyTable.Rows[row].Cells[col].Text) && !String.IsNullOrEmpty(HttpUtility.HtmlDecode(MyTable.Rows[row].Cells[col].Text).Trim()))
    			{
    				hasData = true;
    				break;
    			}
    		}
    		
    	if (!hasData)
    	{
    		MyTable.HeaderRow.Cells[col].Visible = false;
    		for(int hiddenrows = 0; hiddenrows < MyTable.Rows.Count; hiddenrows++)
    		{
    			MyTable.Rows[hiddenrows].Cells[col].Visible = false;
    		}
    	}
    	
    		hasData = false;
    	}
    }
