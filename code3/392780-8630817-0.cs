    using System.Data.SqlClient;
    ....
        SqlConnection objConn = new SqlConnection("Data Source=MYDBSERVER,3306;User ID=kingRoland;Password=12345;Initial Catalog=suggestionDB");
        objConn.Open();
        SqlCommand objCMD = new SqlCommand();
        objCMD.Connection = objConn;
        objCMD.CommandText = "INSERT INTO SuggestionLog (Title,Description,Username) VALUES(@title, @desc, @user)";
        objCMD.Parameters.Clear();
        objCMD.Parameters.AddWithValue("title",strTitle);
        objCMD.Parameters.AddWithValue("desc",strDesc);
        objCMD.Parameters.AddWithValue("user",strUser);
        try
        {
            objCMD.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            writeToLog(e.InnerException.ToString());
        }
        objConn.Close();
