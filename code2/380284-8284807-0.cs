    public FileContentResult GetFile(int id)
    {
      SqlDataReader rdr; byte[] fileContent = null; 
      string mimeType = "";string fileName = "";
      const string connect = @"Server=.\SQLExpress;Database=FileTest;Trusted_Connection=True;";
    
      using (var conn = new SqlConnection(connect))
      {
        var qry = "SELECT FileContent, MimeType, FileName FROM FileStore WHERE ID = @ID";
        var cmd = new SqlCommand(qry, conn);
        cmd.Parameters.AddWithValue("@ID", id);
        conn.Open();
        rdr = cmd.ExecuteReader();
        if (rdr.HasRows)
        {
          rdr.Read();
          fileContent = (byte[])rdr["FileContent"];
          mimeType = rdr["MimeType"].ToString();
          fileName = rdr["FileName"].ToString();
        }
      }
      return File(fileContent, mimeType, fileName);
    }
 
