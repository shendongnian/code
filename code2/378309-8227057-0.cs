    private DataSet BindGridView(List<int> userids)
       { DataSet ds = new DataSet();
         string MysqlStatement = string.format("SELECT OrganisationID, OrganisationName FROM tbl_organisation WHERE OrganisationID in ({0})", String.Join(",", userIds));
        MySqlParameter[] param = new MySqlParameter[1];     
        ds = server.ExecuteQuery(CommandType.Text, MysqlStatement, null);
        Grid_Organisationtable.DataSource = ds;
        Grid_Organisationtable.Columns[0].Visible = false;
        Grid_Organisationtable.DataBind();
        return ds;
    }
