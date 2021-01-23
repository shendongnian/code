    protected void Pre_Render(object sender, EventArgs e)
            {
    
     DataBind();
       
    }
    
    
    
    protected void btn_save_click(object sender, EventArgs e)
    
                {
        SqlCommand command_update = new SqlCommand("Update", connection_save1); 
                            command_update.CommandType = System.Data.CommandType.StoredProcedure;
    
    
                            command_update.Parameters.Add(new SqlParameter("@ViewId", Int32.Parse(Id.Value)));
        SqlParameter Returns = new SqlParameter("@ReturnCode", SqlDbType.Char);
                            Returns.Size = 1;
                            Returns.Direction = ParameterDirection.Output;
                            command_insert.Parameters.Add(Returns);
         bSuccess = command_insert.Parameters["@ReturnCode"].Value.ToString();
        if (bSuccess == "1")
                            {
                                //Response.Write("Insert successful");
                                dd_group.DataBind();
                                dd_group.SelectedValue = command_insert.Parameters["@ReturnCode"].Value.ToString().Trim();
        }
        }
