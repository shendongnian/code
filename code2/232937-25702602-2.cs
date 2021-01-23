    private Holidays[] PopulateArrayWithDates()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
            DateTime[] dtHolidays = new DateTime[] { };
            string sql = @"SELECT HolDate, HolName FROM [Server].DBName.dbo.tblHolidays";
            SqlCommand ADDCmd = new SqlCommand(sql, con);
            DataTable table = new DataTable();
            DataTable tbl = new DataTable();
            Utilities.Holidays[] allRecords = null;
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    var list = new List<Holidays>();
                    while (reader.Read())
                        list.Add(new Holidays { dtHoliday = reader.GetDateTime(0), Desc = reader.GetString(1) });
                    allRecords = list.ToArray();
                }
            }
            return allRecords;
        }
