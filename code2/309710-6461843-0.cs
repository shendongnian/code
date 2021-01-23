    public static IEnumerable<string> GetTracks(string conferenceId)
    {
        using (var sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        using (var cmd = new SqlCommand("select Track_name,Track_ID from TrackCommittee where Conference_id= @conferenceId", sqlCon))
        {
            
            cmd.Parameters.Add("@conferenceId", SqlDbType.Int).Value = conferenceId;
            sqlCon.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    yield return sdr[0].ToString();
                }
            }
        }
    }
