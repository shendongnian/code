                MySqlCommand Command2 = new MySqlCommand(Query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(Command2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Dictionary<string, DataRow> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("username"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
