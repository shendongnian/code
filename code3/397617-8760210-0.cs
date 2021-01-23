    public MemberDetails GetMemberDetail(int membershipgen)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "usp_getmemberdetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MEMBERSHIPGEN", membershipgen);
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
            {
                if (reader.Read())
                {
                    return new MemberDetails(
                        reader.GetInt32(reader.GetOrdinal("MEMBERSHIPGEN")), 
                        reader.GetString(reader.GetOrdinal("MEMBERSHIPID")),
                        reader.GetString(reader.GetOrdinal("LASTNAME")),
                        reader.GetString(reader.GetOrdinal("FIRSTNAME")),
                        reader.GetString(reader.GetOrdinal("SUFFIX")),
                        reader.GetString(reader.GetOrdinal("MEMBERTYPESCODE"))
                    );
                }
                return null;
            }
        }
    }
