    protected void btnDelete_Click(object sender, EventArgs e)
    {
     try
     {
         int i;
         Con.Open();
         cmd = new SqlCommand("USP_REGISTER", Con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@P_CH_ACTION_CODE", "D");
         for ( i = 0; i <= grdApplication.Rows.Count - 1; i++)
         {
             CheckBox Ck=grdApplication.Rows[i].FindControl("cbItem") as CheckBox;
             if (Ck.Checked==true)
                {
                    int Id = (int)grdApplication.DataKeys[i].Values["INT_ID"];
                    cmd.Parameters.AddWithValue("@P_INT_ID", Id);
                    SqlParameter StrOut = new SqlParameter();
                    StrOut = cmd.Parameters.AddWithValue("@P_MSG_OUT", "out");
                    StrOut.Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    StrRetVal = (string)cmd.Parameters["@P_MSG_OUT"].Value;
                }
             Con.Close();
                     }
     
       }
       catch (Exception ex)
       {
           Response.Write(ex.Message);
       }
     }
