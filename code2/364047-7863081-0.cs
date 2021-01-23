    private void lbtnConnect_Click(object sender, System.EventArgs e)
    {
       if (CreateConnectionString())
      CreateModelClassFiles(tcGetDataReader());
    }
    // <summary>
    /// Get the SqlDataReader object
    /// SqlDataReader
    /// </summary>
    public SqlDataReader tcGetDataReader()
    {
    SqlConnection connection = null;
    try
    {
      connection = GetConnection(SQL_CONN_STRING);
      if (connection == null)
      return null;
      SqlDataReader dr = SqlHelper.ExecuteReader(
             connection,
             CommandType.StoredProcedure,
             "getData");
    if (dr.HasRows)
      return dr;
    else
      return null;
     }
     catch(Exception ex)
     {
      MessageBox.Show(ex.Message);
      return null;
     }   
    }
