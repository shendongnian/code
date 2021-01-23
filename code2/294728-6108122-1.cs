    private static DataSet ds;
    private const string query = "select * from tblcountrynames";
    protected void grdViewCInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdViewCInfo.EditIndex = e.NewEditIndex;
        //guessing that this is your databind event
        dbLoad();
    }
    protected void grdViewCInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit)
        {
            //your ddl
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlCountry");
            PopulateCountries(ddl, query);
            //grdViewCInfo.Rows[e.NewEditIndex].Cells[4].Controls.Add(ddl);
        }
    }
    private void PopulateCountries(DropDownList ddl, string query)
    {
        if(ds!= null && ds.Tables[0].Rows.Count >0)
            MySqlConnection objMycon1 = new MySqlConnection(strProvider);
            //commenting open; as adapter doesn't need connection to be open
            //objMycon1.Open();
            MySqlCommand cmd1 = new MySqlCommand(query, objMycon1);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
            ds = new DataSet();
            da.Fill(ds);
            objMycon1.Close();
            objMycon1.Dispose();//comment if objMycon1 is not IDisposible
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ID";
            ddl.DataBind();
        }
    }
