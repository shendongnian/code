    byte[] ImageData;
    string filePath = @"~\Image.jpeg";  //path or temporary Image
    using (con)
    {
        con.Open();
        SqlCommand getImageCmd = new SqlCommand("/* your SQL query to get Image from database*/ ", con);
        ImageData = (byte[])getImageCmd.ExecuteScalar();
        con.Close();
    }
    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
    using (fs)
    {
        foreach (byte b in ImageData)
        {
            fs.WriteByte(b);
        }
        fs.Flush();
        fs.Close();
    }
    ImageControl.ImageUrl = "~/Image.jpeg"; // assign that temp Image to Image Control
