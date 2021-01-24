                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("partno", typeof(string));
                dt.Columns.Add("model", typeof(string));
                dt.Columns.Add("catm", typeof(string));
                dt.Columns.Add("date", typeof(int));
                dt.Rows.Add(new object[] {"1.", "001", "TOYOTA", "CONSIGN", 2010});
                dt.Rows.Add(new object[] {"2.", "001", "HONDA", "CONSIGN", 2009});
                dt.Rows.Add(new object[] {"3.", "001", "HONDA", "BUY", 2015});
                dt.Rows.Add(new object[] {"4.", "001", "TESLA", "CONSIGN", 2018});
                dt.Rows.Add(new object[] {"5.", "001", "TESLA", "CONSIGN", 2018});
                List<DataRow> latest = dt.AsEnumerable()
                    .OrderByDescending(x => x.Field<int>("date"))
                    .Where(x => x.Field<string>("catm") == "BUY" || x.Field<string>("catm") == "A/R")
                    .ToList();
