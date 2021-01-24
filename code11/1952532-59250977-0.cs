                SqlConnection conn = new SqlConnection();
                SqlDataAdapter adapter = new SqlDataAdapter("Your SQL Query", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Dictionary<string, long> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("ReferenceNo"), y => y.Field<long>("Productionpieces"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
