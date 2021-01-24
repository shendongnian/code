    private void FilterData()
        {
            string selectedID = "X0101";
            DataSet dataSet = GetAllUniqueIDs();
            var fullList = dataSet?.Tables[0]
                .AsEnumerable()
                .Select(x => new
                {
                    UniqueID = x.Field<string>("UniqueID")
                });
            var filteredList = from r in fullList where r.UniqueID != selectedID select r;
        }
        private DataSet GetAllUniqueIDs()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("UniqueID");
            DataRow dr = dt.NewRow();
            dr["UniqueID"] = "X0101";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["UniqueID"] = "X0202";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["UniqueID"] = "X0303";
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            ds.Tables.Add(dt);
            return ds;
        }
