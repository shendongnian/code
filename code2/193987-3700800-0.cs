    foreach(DataGridColumnStyle vColumnStyle in myGrid.TableStyles[0].GridColumnStyles )
    {
    	if (vColumnStyle.HeaderText.ToLower()=="mycolumn")    
    	{                
    		vColumnStyle.Width = 60;            
    	}
    }
