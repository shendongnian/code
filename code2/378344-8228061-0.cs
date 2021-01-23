    while (reader.Read())
    {
        Orgid = Convert.ToInt32(reader["OrganisationID"]);
        userids.Add(Orgid);
        if (Orgid != 0)
        {
            BindGridView(Orgid, userids);
        }
    }
    reader.Close();
    
