            for (int lc = 0; lc < 10; lc++) {
                DataTable a = new DataTable();
                a.Columns.Add("ID", typeof(int));
                a.Columns.Add("Name", typeof(string));
                a.Columns.Add("Age", typeof(int));
                DataTable b = new DataTable();
                var pk = b.Columns.Add("ID", typeof(int));
                b.Columns.Add("Address", typeof(string));
                b.Columns.Add("YearsAt", typeof(int));
                b.PrimaryKey = new[] { pk };
                Random r = new Random();
                for (int i = 0; i < 100000; i++)
                {
                    a.Rows.Add(i, Guid.NewGuid().ToString(), r.Next(20, 99));
                    if (r.Next(0, 9) < 1)
                        b.Rows.Add(i, Guid.NewGuid().ToString(), r.Next(1, 10));
                }
                Stopwatch loops = Stopwatch.StartNew();
                //ensure unique named columns in b, and grow a's columns
                foreach (DataColumn bcol in b.Columns) {
                    while (a.Columns.Contains(bcol.ColumnName))
                        bcol.ColumnName += "_";
                    a.Columns.Add(bcol.ColumnName, bcol.DataType);
                }
                //perform left join
                foreach (DataRow aro in a.Rows) {
                    var f = b.Rows.Find(aro["ID"]);
                    if (f != null)
                        foreach (DataColumn bcol in b.Columns)
                            aro[bcol.ColumnName] = f[bcol];
                }
                loops.Stop();
                Stopwatch linq = Stopwatch.StartNew();
                var query =
                    from ae in a.AsEnumerable()
                    join be in b.AsEnumerable() on ae.Field<int>("ID") equals be.Field<int>("ID_") into aebe
                    from be2 in aebe.DefaultIfEmpty()
                    select new object[]
                    {
                    ae.Field<int>("ID"),
                    ae.Field<string>("Name"),
                    ae.Field<int>("Age"),
                    be2?.Field<string>("Address"),
                    be2?.Field<int>("YearsAt")
                    };
                DataTable c = new DataTable();
                c.Columns.Add("ID", typeof(int)); c.Columns.Add("Name"); c.Columns.Add("Age", typeof(int)); c.Columns.Add("Address"); c.Columns.Add("YearsAt");
                foreach (var at in query)
                    c.Rows.Add(at);
                linq.Stop();
                Console.WriteLine($"Loops: {loops.ElapsedMilliseconds}ms, linq: {linq.ElapsedMilliseconds}ms");
            }
