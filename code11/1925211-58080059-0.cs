    public static void DumpAllPhotos()
    {
    	string sql = @"select per.person_id,pho.photo
                    from person as per
                    inner join photo as pho on per.photo_id = pho.photo_id";
        string folder = @"c:\MyFolder"; // output folder
    	using (SqlConnection con = new SqlConnection(_connString))
    	using (SqlCommand cmd = new SqlCommand(sql,con))
    	{
    		con.Open();
    		var rdr = cmd.ExecuteReader();
    		while (rdr.Read())
    		{
    			var bytes = (byte[])rdr["photo"];
    			var path = Path.Combine(folder, $"{rdr["person_id"].ToString()}.bmp");
    			File.WriteAllBytes(path, bytes);
    		}
    		con.Close();
    	}
    }
