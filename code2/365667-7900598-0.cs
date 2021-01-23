    SqlConnection sqlConnection = new SqlConnection(ConnectionString);
    string qrySQL = string.Format("INSERT INTO Tracks ([Track_Name],[Track_No],[Artist_ID],[Album_ID]) VALUES ({0}, {1}, {2}, {3})", Track_Name, TN, ArtID, AlbID);
    SqlCommand sqlCommand = new SqlCommand(qrySQL, sqlConnection);
    sqlConnection.Open();
    sqlCommand.ExecuteNonQuery();
