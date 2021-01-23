    private DataSet BindGridView(int id, List<int> userids)
    {
        string GetOrgIDs = "select OrganisationID from tbl_organisation where ParentID =@ParentID";
        MySqlParameter[] paramet = new MySqlParameter[1];
        paramet[0] = new MySqlParameter("@ParentID", MySqlDbType.Int32);
        paramet[0].Value = id;
        List<int> children = new List<int>(); // new local list
        MySqlDataReader reader = server.ExecuteReader(CommandType.Text, GetOrgIDs, paramet);
        while (reader.Read())
        {
            int orgid = Convert.ToInt32(reader["OrganisationID"]);
            userids.Add(orgid);
            children.Add(orgid);  // also add to local list
        }
        reader.Close();
        foreach(int child in children)
        if (child != 0)
        {
            BindGridView(child, userids);
        }
    }
