        string strQuery = "select Name, ContentType, Data from tblFiles where id=@id";
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
        DataTable dt = GetData(cmd);
        if (dt != null)
        {
            download(dt);
        }
    
        private void download (DataTable dt)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
        
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["ContentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
        
            + dt.Rows[0]["Name"].ToString());
        
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
    }
    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Configuration.ConfigurationManager
        .ConnectionStrings["conString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
            sda.Dispose()
            con.Dispose();
       }
    }
