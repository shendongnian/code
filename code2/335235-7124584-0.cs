    logonName = Session["user"].ToString();
    
        string strSQL = "insertResults";
    	var objDB01 = new dbconn();
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            RadioButtonList rb = gvr.FindControl("answers_list") as RadioButtonList;
            var quest = rb.SelectedValue;
    
            if (quest == "")
            {
                quest = "0";
            }
    
            int questionId = Convert.ToInt32(GridView1.DataKeys[gvr.RowIndex].Values[0].ToString());
            int groupId = Convert.ToInt32(GridView1.DataKeys[gvr.RowIndex].Values[1].ToString());
            int question = Convert.ToInt32(quest);
            
    		objDB01.objCommand.Clear();
            objDB01.objCommand.Parameters.AddWithValue("@userId", logonName);
            objDB01.objCommand.Parameters.AddWithValue("@groupId", groupId);
            objDB01.objCommand.Parameters.AddWithValue("@questionId", questionId);
            objDB01.objCommand.Parameters.AddWithValue("@answer", question);
    		
            objDB01.GetNonQuery(strSQL);
    	}
    	
    	//CLOSE YOUR CONNECTION if dispose does not directly invoke close.	
        objDB01.Dispose();
    	
            
