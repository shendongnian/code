    public void AddImage(object sender, EventArgs e)
    {
        int intImageSize;
        String strImageType;
        Stream ImageStream;
        FileStream fs = File.OpenRead(Request.PhysicalApplicationPath + "/Images/default_image.png");
        Byte[] ImageContent;
        if (PersonImage.PostedFile.ContentLength > 0)
        {
            intImageSize = PersonImage.PostedFile.ContentLength;
            strImageType = PersonImage.PostedFile.ContentType;
            ImageStream = PersonImage.PostedFile.InputStream;
            ImageContent = new Byte[intImageSize];
            int intStatus;
            intStatus = ImageStream.Read(ImageContent, 0, intImageSize);
        }
        else
        {
            strImageType = "image/x-png";
            ImageContent = new Byte[fs.Length];
            fs.Read(ImageContent, 0, ImageContent.Length);
        }
        SqlConnection objConn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlCommand objCmd;
        string strCmd;
        strCmd = "INSERT INTO ImageTest (Picture, PictureType) VALUES (@Picture, @PictureType)";
        objCmd = new SqlCommand(strCmd, objConn);
        SqlParameter prmPersonImage = new SqlParameter("@Picture", SqlDbType.Image);
        prmPersonImage.Value = ImageContent;
        objCmd.Parameters.Add(prmPersonImage);
        objCmd.Parameters.AddWithValue("@PictureType", strImageType);
        lblMessage.Visible = true;
        try
        {
            objConn.Open();
            objCmd.ExecuteNonQuery();
            objConn.Close();
            lblMessage.Text = "ImageAdded!";
        }
        catch
        {
            lblMessage.Text = "Error occured the image has not been added to the database!";
        }
    }
