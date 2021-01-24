    int bmax, bmin;
    using (var reader = cmd.ExecuteReader())
    {
        if (reader.Read())
        {
          if (!reader.IsDBNull(0))
             bmax = reader.GetInt32(0);
          if (!reader.IsDBNull(1))
             bmin = reader.GetInt32(1);
          // and so on
        }
    }
