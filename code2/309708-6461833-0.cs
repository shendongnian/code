    using (SqlDataReader sdr = cmd.ExecuteReader())
    {
      while (sdr.Read())
      {
        res.Add(sdr.GetString(sdr.GetOrdinal("Track_name")));
        trackIds.Add(sdr.GetInt32(sdr.GetOrdinal("Track_ID")).ToString())
      }
    }
