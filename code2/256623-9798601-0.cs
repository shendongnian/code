    protected void butSubmit_Click(object sender, EventArgs e)
    {
    SqlConnection connection = null;
    try
     {
     Byte[] imgByte = null;
       if (FileUpload1.HasFile && FileUpload1.PostedFile != null)
    {
     HttpPostedFile File = FileUpload1.PostedFile;
    imgByte = new Byte[File.ContentLength];
     File.InputStream.Read(imgByte, 0, File.ContentLength);
     }
     connection = new SqlConnection(ConfigurationManager.ConnectionStrings         
     "ConnectionString"].ConnectionString.ToString());
     connection.Open();
    string sql = "INSERT INTO Table1(title,image) VALUES(@theTitle, @theImage) SELECT     
    @@IDENTITY";
     SqlCommand cmd = new SqlCommand(sql, connection);
     cmd.Parameters.AddWithValue("@theTitle", txtTitle.Text);
     cmd.Parameters.AddWithValue("@theImage", imgByte);
     int id = Convert.ToInt32(cmd.ExecuteScalar());
     lblStatus.Text = String.Format("ID is {0}", id);
     Image1.ImageUrl = "~/DisplayImg.ashx?id=" + id;
    }
    {
    lblStatus.Text = "There was an error";
    }
    finally
    {
     connection.Close();
    }
} 
