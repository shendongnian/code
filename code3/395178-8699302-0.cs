        SqlConnection linkToDB = new SqlConnection(strConnection);
        linkToDB.Open(); // <-------
        string sqlText = "SELECT * FROM tblCaseTypes;";
        SqlCommand sqlComm = new SqlCommand(sqlText, linkToDB);
        SqlDataReader sqlReader = sqlComm.ExecuteReader();
