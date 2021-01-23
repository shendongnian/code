    string strSQLCommand; 
    SqlCommand command;
    SqlConnection conn = null;
    conn =new SqlConnection("Data Source=serverName\IP;Initial Catalog=dbActivities;UID=User;PWD=Password;Max Pool Size=500;");
    strSQLCommand = "Your Command";
    command = new SqlCommand(strSQLCommand, conn);
    command.ExecuteNonQuery();
    conn.Close();
            
