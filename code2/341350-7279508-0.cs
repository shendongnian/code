    using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
    try
    {
    const string SQL = "INSERT INTO [BinaryTable] ([FileName], [DateTimeUploaded], [MIME], [BinaryData]) VALUES (@FileName, @DateTimeUploaded, @MIME, @BinaryData)";
    SqlCommand cmd = new SqlCommand(SQL, Conn);
    cmd.Parameters.AddWithValue("@FileName", FileName.Text.Trim());
    cmd.Parameters.AddWithValue("@MIME", FileToUpload.PostedFile.ContentType);
    
    byte[] imageBytes = new byte[FileToUpload.PostedFile.InputStream.Length + 1];
    FileToUpload.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);
    cmd.Parameters.AddWithValue("@BinaryData", imageBytes);
    cmd.Parameters.AddWithValue("@DateTimeUploaded", DateTime.Now);
    
    Conn.Open();
    cmd.ExecuteNonQuery();
    lit_Status.Text = "<br />File successfully uploaded - thank you.<br />";
    Conn.Close();
    }
    catch
    {
    Conn.Close();
    }
    }
