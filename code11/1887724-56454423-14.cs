            //setup part
            DataTable a = new DataTable();
            a.Columns.Add("ID", typeof(int));
            a.Columns.Add("Name", typeof(string));
            a.Columns.Add("Age", typeof(int));
            DataTable b = new DataTable();
            var pk = b.Columns.Add("ID", typeof(int));
            b.Columns.Add("Address", typeof(string));
            b.Columns.Add("YearsAt", typeof(int));
            b.PrimaryKey = new[] { pk };
            a.Rows.Add(1, "John", 22);
            a.Rows.Add(2, "Mary", 33);
            a.Rows.Add(3, "Bill", 44);
            b.Rows.Add(1, "JohnAddr", 3);
            b.Rows.Add(2, "MaryAddr", 4);
