		public byte[] GetImageData(string imageID)
		{
                    string connectionString = ConfigurationManager.ConnectionStrings["connectionstringname"];
			SqlConnection connection = SqlConnection(connectionString);
		    connection.Open();
			SqlCommand command1 = new SqlCommand("select imgfile from myimages where imgname=@imageId", connection);
			SqlParameter myparam = command1.Parameters.Add("@imageId", SqlDbType.NVarChar, 30);
			myparam.Value = imageID;
			byte[] img = (byte[])command1.ExecuteScalar();
			connection.Close();
			return img;
		}
