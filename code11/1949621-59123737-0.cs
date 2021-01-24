            DataTable dt = yourDataTableBefore();
            var query = from uu in dt.AsEnumerable()
                        select new
                        {
                            Name= uu.Field<string>("Name"),
                            Salary = uu.Field<string>("Salary"),
                            Date = uu.Field<string>("Date"),
                            Description = uu.Field<string>("Description"),
                        };
            var result = query.GroupBy(cc => cc.Name).Select(dd => new
            {
                Name = dd.Key,
                Salary = string.Join(",",
                dd.Select(ee => ee.Salary).ToList()),
                Date = dd.Select(ee => ee.Date),
                Description = dd.Select(ee => ee.Description),
            });
            DataTable dt_After = new DataTable();
            dt_After.Columns.Add("Name", typeof(string));
            dt_After.Columns.Add("Salary", typeof(string));
            dt_After.Columns.Add("Date", typeof(string));
            dt_After.Columns.Add("Description", typeof(string));
            foreach (var item in result.ToList())
            {
                var newRow = dt_After.NewRow();
                Array.ForEach(item.GetType().GetProperties(), p => newRow[p.Name] = p.GetValue(item, null));
                dt_After.Rows.Add(newRow);
            }
            foreach (DataRow row in dt_After.Rows)
            {
                List<string> List= row["Salary"].ToString().Split(',').ToList();
                string Sum_Salary = //Iterate through the list, convert them to int and sum it up;
                row["Salary"] = Sum_Salary;
            }
    
    Gridview.DataSource = dt_After;
    Gridview.DataBind();
