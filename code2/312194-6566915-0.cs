            protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection DBConn = new MySqlConnection(WebConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            MySqlCommand DBCmd = new MySqlCommand();
            DBConn.Open();
            
            try
            {
                DBCmd = new MySqlCommand("SELECT VideoID, ImgFileName FROM (SELECT VideoID, ImgFileName FROM videos ORDER BY Rank DESC) as myalias LIMIT 10", DBConn);
                MySqlDataReader reader = DBCmd.ExecuteReader();
                String ImgFileName;
                Int64 VidID;
                while (reader.Read())
                {
                    ImgFileName = reader["ImgFileName"].ToString().Trim();
                    VidID = (Int64)reader["VideoID"];
                    ImageButton imgBtn = new ImageButton();
                    imgBtn.ID = "image_id";
                    imgBtn.ImageUrl = "~/Uploads/Thumbs/" + ImgFileName;
                    imgBtn.PostBackUrl = "~/PlayVideo.aspx?video=" + VidID;
                    placeHolder.Controls.Add(imgBtn);
                }
                reader.Close();
            catch (Exception exp)
            {
                Response.Write(exp);
            }
            DBCmd.Dispose();
            DBConn.Close();
            DBConn = null;
        }
