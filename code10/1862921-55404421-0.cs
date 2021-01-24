            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8" };
            DataTable dt = new DataTable();
            dt.Columns.Add("v1");
            dt.Columns.Add("v2");
            dt.Columns.Add("v3");
            dt.Columns.Add("v4");
            DataRow row = dt.NewRow();
            int col = 0;
            foreach (var val in arr)
            {
                if (col > 3)
                {
                    col = 0;
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                    row[col] = val;
                }
                else
                {
                    row[col] = val;
                    col++;
                }
            }
            dt.Rows.Add(row);
