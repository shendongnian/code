    string delNonQuery = string.Format("DELETE FROM " + Settings.DataSource + " WHERE {0}=@keyuid", Settings.KeyColumn);
    
    SqlCommand cmd = new SqlCommand(delNonQuery,readerConn);
    SqlParameter key = new SqlParameter("keyuid", SqlDbType.VarChar);
    cmd.Parameters.Add(key).Value = Page.Request["key"].ToString().Trim();
    
    readerConn.Open();
    cmd.ExecuteScalar();
    readerConn.Close();
