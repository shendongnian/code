            MyTableAdapter t = new MyTableAdapter2();
            // create the TVP parameter, with one column. the name is irrelevant.
            DataTable tvp = new DataTable();
            tvp.Columns.Add();
            // add one row for each value
            DataRow row = tvp.NewRow();
            row[0] = 1;
            tvp.Rows.Add(row);
            row = tvp.NewRow();
            row[0] = 2;
            tvp.Rows.Add(row);
            row = tvp.NewRow();
            row[0] = 3;
            tvp.Rows.Add(row);
            t.Fill(new MyDataTable(), tvp);
