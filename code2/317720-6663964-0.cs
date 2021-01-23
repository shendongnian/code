    List<string> objList = new List<string>();        
    
    foreach (GridViewRow gvrow in GridView1.Rows)
    {
        CheckBox CheckBox1 = (CheckBox)gvrow.FindControl("CheckBox1");
        if (CheckBox1.Checked)
        {
          objList.Add(row["id"].Text);    
        }
    }
