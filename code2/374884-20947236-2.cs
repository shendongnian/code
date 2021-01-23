    using System.Data.OracleClient;
    
    OracleConnection objConnection = new OracleConnection();
    OracleCommand objCommand = new OracleCommand();
    try
    {
        objConnection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["YourConnectionString"].ToString();
    
        if (objConnection.State != System.Data.ConnectionState.Open)
        {
            objConnection.Open();
        }
    
        objCommand.Connection = objConnection;
    
        //Create Temporary LOB @Start
        //Error Without Temp LOB { ORA-01460: unimplemented or unreasonable conversion requested }
        objCommand.CommandText = "DECLARE dpBlob BLOB; BEGIN DBMS_LOB.CREATETEMPORARY(dpBlob, False, 0); :tmpBlob := dpBlob; END;";
        objCommand.Parameters.Add(new OracleParameter("tmpBlob", OracleType.Blob)).Direction = System.Data.ParameterDirection.Output;
        objCommand.ExecuteNonQuery();
        OracleLob tempLob = default(OracleLob);
        tempLob = (OracleLob)objCommand.Parameters[0].Value;
        tempLob.BeginBatch(OracleLobOpenMode.ReadWrite);
        tempLob.EndBatch();
        objCommand.Parameters.Clear();
        //Create Temporary LOB @End
    
        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        objCommand.CommandText = "INSERT_BLOB";
    
        objCommand.Parameters.AddWithValue("IN_USERNAME", "Sample Name");
        objCommand.Parameters.AddWithValue("IN_UPLOADED_BY", "Sample Name");
    
        string excelFileName = FileUpload1.PostedFile.FileName;
        int intlength = FileUpload1.PostedFile.ContentLength;
    
        Byte[] byteData = new Byte[intlength];
        FileUpload1.PostedFile.InputStream.Read(byteData, 0, intlength);
    
        objCommand.Parameters.AddWithValue("IN_ATTACH_FILE_ORIGINAL", excelFileName);
        objCommand.Parameters.Add("IN_ATTACH_BLOB_ORIGINAL", OracleType.Blob).Value = tempLob;
    
        objCommand.ExecuteNonQuery();
    
    }
    catch (Exception ex)
    {
    }
    finally
    {
        objCommand.Parameters.Clear();
        if (objConnection.State != System.Data.ConnectionState.Closed)
            objConnection.Close();
    }
