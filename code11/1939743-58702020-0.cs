                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Class", typeof(string));
                dt.Columns.Add("Year", typeof(int));
                dt.Columns.Add("EffectiveDate", typeof(DateTime));
                dt.Columns.Add("Value", typeof(int));
                dt.Columns.Add("RangeMin", typeof(int));
                dt.Columns.Add("RangeMax", typeof(int));
                dt.Rows.Add(new object[] {1, "A", 2019, DateTime.Parse("2019/1/1"), 850,1, 100}); 
                dt.Rows.Add(new object[] {2, "A", 2019, DateTime.Parse("2019/1/15"), 840,1, 100}); 
                dt.Rows.Add(new object[] {3, "A", 2019, DateTime.Parse("2019/2/1"), 550,101, 200}); 
                dt.Rows.Add(new object[] {4, "B", 2019, DateTime.Parse("2019/1/5"), 540,1, 100}); 
                dt.Rows.Add(new object[] {5, "B", 2020, DateTime.Parse("2019/1/5"), 650,1, 100}); 
                dt.Rows.Add(new object[] {6, "B", 2020, DateTime.Parse("2019/5/1"), 670,101, 200}); 
                dt.Rows.Add(new object[] {7, "B", 2020, DateTime.Parse("2019/5/2"), 680,101, 200});
                DataTable results = dt.AsEnumerable()
                    .OrderByDescending(x => x.Field<int>("Year"))
                    .ThenByDescending(x => x.Field<DateTime>("EffectiveDate"))
                    .GroupBy(x => new { cl = x.Field<string>("Class"), month = new DateTime(x.Field<DateTime>("EffectiveDate").Year, x.Field<DateTime>("EffectiveDate").Month, 1) })
                    .Select(x => x.FirstOrDefault())
                    .CopyToDataTable();
