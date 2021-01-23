    var intDoccumentLength = FileUpload1.PostedFile.ContentLength;
    var newDocument = new byte[intDoccumentLength];
    var stream = FileUpload1.PostedFile.InputStream;
    stream.Read(newDocument, 0, intDoccumentLength);
    var sqlConnection = new SqlConnection(sqlConnectionString);
    sqlConnection.Open();
    var sqlQuery = "INSERT INTO dbo.DocumentData (DocName, DocBytes, DocData, DocCreatedAt) VALUES (@DocName, @DocBytes, @DocData, @DocCreatedAt);"
					           + "SELECT CAST(SCOPE_IDENTITY() AS INT)";
    sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
    sqlCommand.Parameters.Add("@DocName", SqlDbType.NVarChar, 255);
    sqlCommand.Parameters.Add("@DocBytes", SqlDbType.Int);
    sqlCommand.Parameters.Add("@DocData", SqlDbType.VarBinary);
    sqlCommand.Parameters.Add("@DocCreatedAt", SqlDbType.DateTime);
    sqlCommand.Parameters["@DocName"].Value = FileUpload1.PostedFile.FileName;
    sqlCommand.Parameters["@DocBytes"].Value = intDoccumentLength;
    sqlCommand.Parameters["@DocData"].Value = newDocument;
    sqlCommand.Parameters["@DocCreatedAt"].Value = DateTime.Now;
    var newDocumentId = (Int32) sqlCommand.ExecuteScalar();
    sqlConnection.Close();
