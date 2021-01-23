     using (var sqlCon  = new SqlConnection(...))
     { 
        sqlCon.Open();
        using (SqlCommand cmd = new SqlCommand("...", sqlCon)
        {
            cmd.Parameters.Add(new SqlParameter("@conferenceId", conferenceId));
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    res.Add(sdr[0]);
                    trackIds.Add (srd[1]);
                }
            }
        }
      }
      return res;
