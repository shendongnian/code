    bool atLeastOneRowDeleted = false;
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("UserSelection");
            if (cb != null && cb.Checked)
            {
                atLeastOneRowDeleted = true;
                //assuming you have the ID column after the controls
                string CusId = (row.Cells[3].Text);
           SqlConnection conn = new SqlConnection("Data Source=DATASOURCE");
           string sql = string.Format("DELETE FROM [UserDB] where Employee like '%{0}%'",userID);
           SqlCommand cmd = new SqlCommand(sql,conn);
           conn.Open();
           cmd.ExecuteNonQuery();
            }
        }
