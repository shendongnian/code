    private static int GetRefurbRate(string repairOrd, int totalUnits, string connection, string schema)
    {
        if (string.IsNullOrEmpty(repairOrd))
            return 0;
        if (totalUnits == 0)
            return 0;
        if (string.IsNullOrEmpty(connection))
            throw new ArgumentException("Missing database connection for getting the refurb rate.");
        if (string.IsNullOrEmpty(schema))
            throw new ArgumentException("Missing schema for getting the refurb rate.");
        string sql = string.Format(@"
                 SELECT COUNT(*) AS TotalRefurb
                 FROM {0}.repair_part rp 
                 WHERE rp.repair_ord = @repair_ord
             ", schema);
        int totalRefurb;
        using (SqlConnection conn = new SqlConnection(connection))
        {
            conn.Open();
            using (SqlCommand comm = new SqlCommand(sql, conn))
            {
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@repair_ord", repairOrd);
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    reader.Read();
                    totalRefurb = (int)reader["TotalRefurb"];
                }
            }
        }
        return totalRefurb / totalUnits * 100;
    }
