       int topID = 0;
       string TopIDQuery = "Select TopID from tbl_Organisation where OrganisationID=@OrgID";
       
       paramet[0] = new MySqlParameter("@OrgID", MySqlDbType.Int32);
       paramet[0].Value = OrgID;
       
       using (reader = server.ExecuteReader(CommandType.Text, TopIDQuery, paramet))
       {
           while (reader.Read())
           {
               topID = reader.IsDBNull("TopID") ? 0 : Convert.ToInt32(reader["TopID"]);
           }
       }
