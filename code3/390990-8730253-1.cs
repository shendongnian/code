            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id", typeof(System.Int32)),
                new DataColumn("Name", typeof(System.String))
            });
            dt.Rows.Add (new Object[]{1,"Test"});
            dt.Rows.Add(new Object[] {2, "Test" });
            var l = new Int32[] {  2, 4 };
            var l1 = dt.AsEnumerable().Where(p1 => Array.IndexOf(l, p1.Field<Int32>(0))<0).CopyToDataTable();
