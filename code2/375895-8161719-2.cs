    foreach (DataRow dtrow in dtTable.Rows) 
            { 
    			bool skip = false;
    			
    			foreach (var pane in NavigateAccordion.Panes)
    			{
    				if (pane.HeaderContainer.Controls[0].Text == dtRow[0].ToString())
    				{
    					skip = true;
    					break;
    				}
    			}
    		
    			if (!skip)
    			{
    				string idRow = dtrow[0].ToString(); 
    				AccordionPane currentPane = new AccordionPane(); 
    				currentPane.ID = "AccordionPane" + Guid.NewGuid().ToString(); 
    				currentPane.HeaderContainer.Controls.Add(new LiteralControl(dtrow[0].ToString())); 
    				foreach(DataRow dtRow2 in dtTable.Rows) 
    				{ 
    					if(dtRow2[0].ToString() == idRow) 
    					{ 
    						currentPane.ContentContainer.Controls.Add(new LiteralControl(dtRow2[1].ToString())); 
    					} 
    				} 
    				NavigateAccordion.Panes.Add(currentPane); 
    			}
            } 
