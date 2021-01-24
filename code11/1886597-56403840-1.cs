    var TheLoaiIds = lbxTheLoai.GetSelectedIndices();
    string CStr = "YourConnectionString";
    string Query = "INSERT INTO ChiTietTL VALUES ('" + TheLoaiId + "', @MaPhim)";
    using(var conn = new SqlConnection(CStr))
    {
        foreach (var TheLoaiId in TheLoaiIds)
        {
            using(var cmd = new SqlCommand(Query, conn))
            {
                 try
                 {
                     cmd.Parameters.AddWithValue("@MaPhim", TheLoaiId);
                     cmd.ExecuteNonQuery();
                 }
                 catch (SqlException ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
             }
         }
    }
