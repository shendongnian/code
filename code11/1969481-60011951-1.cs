    using (var sc = DBManager.CreateConnection())
    {
        sc.Open();
        var tran = sc.BeginTransaction();
        foreach (string item in listSurfaceTypes)
        {
            SqlCommand insert = new SqlCommand("INSERT INTO dbo.surface_type_inspection (InspectionID,SurfaceType) values(@InspecId,@SurfaceType)", sc);
            insert.Parameters.AddWithValue("@InspecId", id);
            insert.Parameters.AddWithValue("@SurfaceType", item);
    
            insert.Transaction = tran;
            insert.ExecuteNonQuery();
        }
        tran.Commit();
        sc.Close();
    }
