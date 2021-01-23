    //base class
    public class SQLInsertBase
    {
      public bool SQLInsertOK;
      public string SQLInsertError;
      public string lat;
      public string lon;
      public string id;
      public SQLInsertBase()
    {
        //
        // TODO: Add constructor logic here
        //
       }
    }
    public SQLInsertBase GetSQLInsertCourse(string id,string lat,string lon)
    {
        string cmdString = "INSERT into Location values(@id,@latitude,@longitude)";
        SqlConnection sqlConnection = new SqlConnection();
        SQLInsertBase GetSQLResult = new SQLInsertBase();
        SqlDataReader sqlReader;
        GetSQLResult.SQLInsertOK = true;
        sqlConnection = SQLConn();
        if (sqlConnection == null)
        {
            GetSQLResult.SQLInsertError = "Database connection is failed";
            ReportError1(GetSQLResult);
            return null;
        }
        SqlCommand sqlCommand = new SqlCommand(cmdString, sqlConnection);
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.Parameters.Add("@id", SqlDbType.Text).Value = id;
        sqlCommand.Parameters.Add("@latitude", SqlDbType.Text).Value = lat;
        sqlCommand.Parameters.Add("@longitude", SqlDbType.Text).Value = lon;
        int result = sqlCommand.ExecuteNonQuery();
      //  if (sqlReader.HasRows == true)
       //     FillCourseDetail(ref GetSQLResult, sqlReader);
        if (result == 0)
        {
            GetSQLResult.SQLInsertError = "cannot update ";
            ReportError1(GetSQLResult);
        }
       /* else
        {
            GetSQLResult.SQLInsertError = "No matched  found";
            ReportError1(GetSQLResult);
        }*/
      //  sqlReader.Close();
        sqlConnection.Close();
        sqlCommand.Dispose();
        return GetSQLResult;
    }
     protected SqlConnection SQLConn()
      {
        string cmdString =     ConfigurationManager.ConnectionStrings["sql_conn"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = cmdString;
        conn.Open();
        if (conn.State != System.Data.ConnectionState.Open)
        {
            MessageBox.Show("Database Open  failed");
            conn = null;
        }
        return conn;
    }
    protected void ReportError1(SQLInsertBase ErrSource)
    {
        ErrSource.SQLInsertOK = false;
        MessageBox.Show(ErrSource.SQLInsertError);
    }
