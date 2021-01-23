    HtmlTable tbProductImage = new HtmlTable();
    HtmlTableRow trImageRow = new HtmlTableRow();
    for (int j = 0; j < columnCount; j++)
    {
    	if (filteredFileList.Count != 0)
    	{
    		HtmlTableCell tdImageRow = new HtmlTableCell();
    		Panel panel = new Panel();
    		ImageButton btnProduct = new ImageButton();
    		
    		btnProduct.ID = "btn" + filteredFileList[j].Name.Substring(0, filteredFileList[j].Name.LastIndexOf("."));
    		btnProduct.ImageUrl = @"/ysyp/Images/Products/" + filteredFileList[j].Name;
    		btnProduct.Width = 50;
    		btnProduct.CommandName = "Click";
    		
    		Page.ClientScript.GetPostBackEventReference(btnProduct, "btnProduct_Click");
    		
    		btnProduct.CommandArgument = filteredFileList[j].Name;
    		btnProduct.Click += new ImageClickEventHandler(btnProduct_Click);
    		
    		panel.Controls.Add(btnProduct);
    		
    		trImageRow.Cells.Add(tdImageRow);
    		tdImageRow.Controls.Add(panel);
    	}
    }
    
    tbProductImage.Rows.Add(trImageRow);
    tdProduct.Controls.Add(tbProductImage);
