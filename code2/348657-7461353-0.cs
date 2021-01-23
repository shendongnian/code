    string sqlcommand = "select * from itemmaster";//itemaster contains id field which is primary key//
    
    SqlConnection cn = new SqlConnection(connstring);
    cn.Open();
    SqlCommand cmd = new SqlCommand(sqlcommand, cn);
    
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    SqlCommand deleteCmd = new SqlCommand("DELETE FROM itemmaster WHERE ID = @ID", cn);
    SqlParameter deleteParam = deleteCmd.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
    deleteParam.SourceVersion = DataRowVersion.Original;
    da.DeleteCommand = deleteCmd;
    
    DataSet ds = new DataSet();
    da.FillSchema(ds, SchemaType.Source, "itemmaster");
    da.Fill(ds, "itemmaster");
    ds.Tables[0].Rows[4].Delete();
    da.Update(ds, "itemmaster");
