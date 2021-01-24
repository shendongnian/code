     private static DataTable GetDataTableTwo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("name", System.Type.GetType("System.String"));
            DataRow row = dt.NewRow();
            row["id"] = "1";
            row["name"] = "Farhin";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["id"] = "2";
            row["name"] = "salli";
            dt.Rows.Add(row);
            
            return dt;
        }
        private static DataTable GetDataTableOne()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("name", System.Type.GetType("System.String"));
            dt.Columns.Add("city", System.Type.GetType("System.String"));
            DataRow row = dt.NewRow();
            row["id"] = "1";
            row["name"] = "Farhin";
            row["city"] = "new city row 1";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["id"] = "2";
            row["name"] = "salli";
            row["city"] = "new city row 2";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["id"] = "3";
            row["name"] = "John";
            row["city"] = "new city row 3";
            dt.Rows.Add(row);
            return dt;
        }
