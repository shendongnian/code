     // FOR SEAT ALPHABETS (BLUE COLOR) 
    for (int row = 0; row < dsSeatMaster.Tables[0].Rows.Count; row++) 
    { 
    	for (int col = 0; col < dsSeatMaster.Tables[0].Columns.Count; col++) 
    	{ 
    		if (dsSeatMaster.Tables[0].Rows[row]["Row"].ToString() == alpha) 
    		{ 
    			tc.BackColor = System.Drawing.ColorTranslator.FromHtml(dsSeatMaster.Tables[0].Rows[row]["ColorCode"].ToString()); 
    			tc.Attributes.Add("style", "text-align:center"); 
    
    		}                
    	} 
    } 
    
    // FOR CATEGORY COLOR 
    
    for (int row = 0; row < dsSeatMaster.Tables[0].Rows.Count; row++) 
    { 
    	for (int col = 0; col < dsSeatMaster.Tables[0].Columns.Count; col++) 
    	{ 
    
    		if (dsSeatMaster.Tables[0].Rows[row]["Row"].ToString() == alpha) 
    		{ 
    			tc.BackColor = System.Drawing.ColorTranslator.FromHtml(dsSeatMaster.Tables[0].Rows[row]["CategoryColor"].ToString()); 
    			tc.Attributes.Add("style", "text-align:center"); 
    		} 
    	} 
    } 
