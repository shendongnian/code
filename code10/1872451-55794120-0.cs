                DataTable dt = new DataTable();
                Dictionary<string, DataRow> dict1 = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Name"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, List<DataRow>> dict2 = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Name"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
