            for (int lc = 0; lc < 10; lc++) {
                //setup 100K rows
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
                Stopwatch sw = Stopwatch.StartNew();
    ### INSERT CHOSEN METHOD HERE ###
                sw.Stop();
                Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms");
            }
