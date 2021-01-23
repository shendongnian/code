    public void rebind()
        {
    
            try
            {
                OdbcConnection myConn = new OdbcConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
                string sql = "select casename,casecode from casetype";
                myConn.Open();
                OdbcCommand cmd = new OdbcCommand(sql, myConn);
                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "casename";
                DropDownList3.DataValueField = "casecode";
                DropDownList3.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace);
            }
        }
